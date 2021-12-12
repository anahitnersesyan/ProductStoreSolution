using ProductStore.Shared.DTOs.Models;

namespace ProductStore.Shared.DTOs
{
    public class UpdateProductCountOutDTO : BaseOutDTO
    {
        public ProductDTO Product { get; set; }
    }
}
