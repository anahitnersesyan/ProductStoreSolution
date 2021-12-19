using Microsoft.AspNetCore.Mvc;
using ProductStore.Core.Interfaces.IBLL;
using ProductStore.Shared.DTOs;
using System.Threading.Tasks;

namespace ProductStore.API.Controllers
{
    [Route("api/Product/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected IProductBL _productBL;

        public ProductController(IProductBL productBL)
        {
            _productBL = productBL;
        }

        [HttpPost("InputProduct")]
        public async Task<InputProductOutDTO> InputProductAsync(InputProductInDTO inModel)
        {
            return await _productBL.InputProductAsync(inModel);
        }

        [HttpPost("AddProductCount")]
        public async Task<AddProductCountOutDTO> AddProductCountAsync(AddProductCountInDTO inModel)
        {
            return await _productBL.AddProductCountAsync(inModel);
        }
    }
}
