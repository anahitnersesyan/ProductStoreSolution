using System.ComponentModel.DataAnnotations;

namespace ProductStore.Shared.DTOs
{
    public class SellProductInDTO
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
