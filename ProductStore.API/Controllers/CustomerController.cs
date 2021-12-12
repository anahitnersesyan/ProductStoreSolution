using Microsoft.AspNetCore.Mvc;
using ProductStore.Core.Interfaces.IBLL;
using ProductStore.Shared.DTOs;
using System.Threading.Tasks;

namespace ProductStore.API.Controllers
{
    [Route("api/Customer/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        protected readonly ICustomerBL _customerBL;

        public CustomerController(ICustomerBL customerBL)
        {
            _customerBL = customerBL;
        }

        [HttpPost("AddCustomer")]
        public async Task<AddCustomerOutDTO> AddCustomerAsync (AddCustomerInDTO inModel)
        {
            return await _customerBL.AddCustomerAsync(inModel);
        }

        [HttpPost("SellProduct")]
        public async Task<SellProductOutDTO> SellProductAsync(SellProductInDTO inModel)
        {
            return await _customerBL.SellProductToCustomerAsync(inModel);
        }

        [HttpPost("ReportSales")]  
        public async Task<ReportSalesOutDTO> ReportSalesAsync(ReportSalesInDTO inModel)
        {
            return await _customerBL.ReportSalesAsync(inModel);
        }

        [HttpPost("ReportCustomers")]
        public async Task<ReportCustomersOutDTO> ReportCustomersAsync(ReportCustomersInDTO inModel)
        {
            return await _customerBL.ReportCustomersAsync(inModel);
        }
    }
}
