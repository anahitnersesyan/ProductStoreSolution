using ProductStore.Shared.DTOs;
using System.Threading.Tasks;

namespace ProductStore.Core.Interfaces.IBLL
{
    public interface ISectionBL
    {
        Task<CreateSectionOutDTO> CreateSectionAsync(CreateSectionInDTO inModel);
        Task<RemoveSectionOutDTO> RemoveSectionAsync(RemoveSectionInDTO inModel);

    }
}
