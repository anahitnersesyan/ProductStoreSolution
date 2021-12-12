using ProductStore.Shared.DTOs.Models;

namespace ProductStore.Shared.DTOs
{
    public class InputProductOutDTO : BaseOutDTO
    {
        public ProductDTO Product { get; set; }
    }
}
