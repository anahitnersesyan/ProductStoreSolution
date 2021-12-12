using System.ComponentModel.DataAnnotations;

namespace ProductStore.Shared.DTOs
{
    public class RemoveSectionInDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
