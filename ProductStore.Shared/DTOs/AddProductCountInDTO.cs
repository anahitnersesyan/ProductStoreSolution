using System.ComponentModel.DataAnnotations;

namespace ProductStore.Shared.DTOs
{
    public class AddProductCountInDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int AddedProductsCount { get; set; }
       
    }
}
