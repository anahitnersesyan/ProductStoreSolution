using Microsoft.AspNetCore.Mvc;
using ProductStore.Core.Interfaces.IBLL;
using ProductStore.Shared.DTOs;
using System.Threading.Tasks;

namespace ProductStore.API.Controllers
{
    [Route("api/Section/")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        protected readonly ISectionBL _sectionBL;

        public SectionController(ISectionBL sectionBL)
        {
            _sectionBL = sectionBL;
        }

        [HttpPost("CreateSection")]
        public async Task<CreateSectionOutDTO> CreateSectionAsync(CreateSectionInDTO inModel)
        {
            return await _sectionBL.CreateSectionAsync(inModel);
        }

        [HttpDelete("RemoveSection")]
        public async Task<RemoveSectionOutDTO> RemoveSectionAsync(RemoveSectionInDTO inModel)
        {
            return await _sectionBL.RemoveSectionAsync(inModel);
        }
    }
}
