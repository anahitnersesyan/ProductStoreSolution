using System.ComponentModel.DataAnnotations;

namespace ProductStore.Shared.DTOs
{
    public class InputProductInDTO
    {
        [Required]
        public string BarCode { get; set; }
        [Required]
        public int SectionId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
