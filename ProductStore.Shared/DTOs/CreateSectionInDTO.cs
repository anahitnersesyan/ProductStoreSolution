using System.ComponentModel.DataAnnotations;

namespace ProductStore.Shared.DTOs
{
    public class CreateSectionInDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
