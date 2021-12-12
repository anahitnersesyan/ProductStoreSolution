using ProductStore.Shared.DTOs.Models;

namespace ProductStore.Shared.DTOs
{
    public class AddCustomerOutDTO : BaseOutDTO
    {
        public CustomerDTO Customer { get; set; }
    }
}
