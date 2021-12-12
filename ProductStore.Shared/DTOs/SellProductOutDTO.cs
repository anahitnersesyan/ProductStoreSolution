using ProductStore.Shared.DTOs.Models;

namespace ProductStore.Shared.DTOs
{
    public class SellProductOutDTO : BaseOutDTO
    {
        public CustomerProductDTO CustomerProduct { get; set; }
    }
}
