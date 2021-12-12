using ProductStore.Shared.DTOs.Models;

namespace ProductStore.Shared.DTOs
{
    public class CreateSectionOutDTO : BaseOutDTO
    {
        public SectionDTO Section { get; set; }
    }
}
