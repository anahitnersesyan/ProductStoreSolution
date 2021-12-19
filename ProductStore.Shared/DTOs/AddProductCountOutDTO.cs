using ProductStore.Shared.DTOs.Models;

namespace ProductStore.Shared.DTOs
{
    public class AddProductCountOutDTO : BaseOutDTO
    {
        public ProductDTO Product { get; set; }
    }
}
