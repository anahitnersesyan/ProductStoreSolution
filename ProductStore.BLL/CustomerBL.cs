using AutoMapper;
using ProductStore.Core.DataModels;
using ProductStore.Core.Interfaces.IBLL;
using ProductStore.Core.Interfaces.IRepositories;
using ProductStore.Shared.DTOs;
using ProductStore.Shared.DTOs.Models;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.BLL
{
    public class CustomerBL : ICustomerBL
    {
        protected readonly ICustomerRepository _customerRepository;
        protected readonly IProductRepository _productRepository;
        protected readonly ICustomerProductRepository _customerProductRepository;
        protected readonly IMapper _mapper;

        public CustomerBL(ICustomerRepository customerRepository,
                          ICustomerProductRepository customerProductRepository,
                          IProductRepository productRepository,
                          IMapper mapper)
        {
            _customerRepository = customerRepository;
            _customerProductRepository = customerProductRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<AddCustomerOutDTO> AddCustomerAsync(AddCustomerInDTO inModel)
        {
            AddCustomerOutDTO result = new AddCustomerOutDTO();

            var customerExists = await _customerRepository.AnyAsync(a => a.Phone == inModel.Phone);

            if (customerExists)
            {
                result.ErrorMessage = $"Customer with phone = {inModel.Phone} already exists";
                return result;
            }

            Customer customer = _mapper.Map<Customer>(inModel);

            await _customerRepository.AddAsync(customer);

            result.Customer = _mapper.Map<CustomerDTO>(customer);

            return result;
        }

        public async Task<ReportCustomersOutDTO> ReportCustomersAsync(ReportCustomersInDTO inModel)
        {
            ReportCustomersOutDTO result = new ReportCustomersOutDTO();

            var sales = await _customerProductRepository.FindThenIncludeAsync(x => x.Date >= inModel.StartDate && x.Date <= inModel.EndDate, y => y.Customer, z => z.Product);

            var groupedSales = sales.GroupBy(t => t.CustomerId);

            foreach (var child in groupedSales)
            {
                if (child.Count() >= 3)
                {
                    foreach (var item in child)
                    {
                        result.Reports.Add(new CustomerReportDTO
                        {
                            Date = item.Date,
                            FirstName = item.Customer.FirstName,
                            LastName = item.Customer.LastName,
                            Phone = item.Customer.Phone,
                            Count = item.Count,
                            Volume = item.Count * item.Product.Price
                        });
                    }
                }
            }

            return result;
        }

        public async Task<SellProductOutDTO> SellProductToCustomerAsync(SellProductInDTO inModel)
        {
            SellProductOutDTO result = new SellProductOutDTO();

            var customerExists = await _customerRepository.AnyAsync(a => a.Id == inModel.CustomerId);

            if (!customerExists)
            {
                result.ErrorMessage = $"Customer with Id={inModel.CustomerId} doesn't exist.";
                return result;
            }

            var product = await _productRepository.FindAsync(a => a.Id == inModel.ProductId);

            if (product == null)
            {
                result.ErrorMessage = $"Product with Id={inModel.ProductId} doesn't exist";
                return result;
            }

            if (inModel.Count > product.Count)
            {
                result.ErrorMessage = $"Do not have enough products!";
                return result;
            }

            CustomerProduct customerProduct = _mapper.Map<CustomerProduct>(inModel);

            product.Count -= customerProduct.Count;

            await _customerProductRepository.AddAsync(customerProduct);

            await _productRepository.UpdateAsync(product);

            result.CustomerProduct = _mapper.Map<CustomerProductDTO>(customerProduct);

            return result;
        }

        public async Task<ReportSalesOutDTO> ReportSalesAsync(ReportSalesInDTO inModel)
        {
            ReportSalesOutDTO result = new ReportSalesOutDTO();

            var sales = await _customerProductRepository.FindThenIncludeAsync(x => x.Date >= inModel.StartDate && x.Date <= inModel.EndDate, y => y.Product);

            result.Reports = sales.Select(a => new SaleReportDTO
            {
                Date = a.Date,
                Count = a.Count,
                BarCode = a.Product.BarCode,
                SectionId = a.Product.SectionId,
                Price = a.Product.Price,
                Income = a.Count * (a.Product.Price - a.Product.Cost)
            }).ToList();

            return result;
        }
    }
}
