using System.ComponentModel.DataAnnotations;

namespace ProductStore.Shared.DTOs
{
    public class UpdateProductCountInDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int AddedProductsCount { get; set; }
       
    }
}
