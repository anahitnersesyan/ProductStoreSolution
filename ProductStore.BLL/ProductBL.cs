using AutoMapper;
using ProductStore.Core.DataModels;
using ProductStore.Core.Interfaces.IBLL;
using ProductStore.Core.Interfaces.IRepositories;
using ProductStore.Shared.DTOs;
using ProductStore.Shared.DTOs.Models;
using System.Threading.Tasks;

namespace ProductStore.BLL
{
    public class ProductBL : IProductBL
    {
        protected readonly IProductRepository _productRepository;
        protected readonly ISectionRepository _sectionRepository;
        protected readonly IMapper _mapper;

        public ProductBL(IProductRepository productRepository, 
                         ISectionRepository sectionRepository,
                         IMapper mapper)
        {
            _productRepository = productRepository;
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<InputProductOutDTO> InputProductAsync(InputProductInDTO inModel)
        {
            InputProductOutDTO result = new InputProductOutDTO();

            var productExists = await _productRepository.AnyAsync(a => a.BarCode == inModel.BarCode);           

            if (productExists)
            {
                result.ErrorMessage = $"Product already exists with BarCode={inModel.BarCode}";
                return result;
            }

            var sectionExists = await _sectionRepository.AnyAsync(a => a.Id == inModel.SectionId);

            if(!sectionExists)
            {
                result.ErrorMessage = $"Section with id={inModel.SectionId} doesn't exist.";
                return result;
            }
           
            Product product = _mapper.Map<Product>(inModel);

            await _productRepository.AddAsync(product);

            result.Product = _mapper.Map<ProductDTO>(product);

            return result;
        }
    
        public async Task<AddProductCountOutDTO> AddProductCountAsync(AddProductCountInDTO inModel)
        {
            AddProductCountOutDTO result = new AddProductCountOutDTO();

            var product = await _productRepository.FindAsync(a => a.Id == inModel.Id);

            if (product == null)  
            {
                result.ErrorMessage = $"Product with Id={inModel.Id} doesn't exist.";
                return result;           
            }

            product.Count += inModel.AddedProductsCount;

            await _productRepository.UpdateAsync(product);

            result.Product = _mapper.Map<ProductDTO>(product);

            return result;
        }
    }
}
