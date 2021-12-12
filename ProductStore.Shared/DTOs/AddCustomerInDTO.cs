using System.ComponentModel.DataAnnotations;

namespace ProductStore.Shared.DTOs
{
    public class AddCustomerInDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
