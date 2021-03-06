using ProductStore.Shared.DTOs;
using System.Threading.Tasks;

namespace ProductStore.Core.Interfaces.IBLL
{
    public interface IProductBL
    {
        Task<InputProductOutDTO> InputProductAsync(InputProductInDTO inModel);
        Task<AddProductCountOutDTO> AddProductCountAsync(AddProductCountInDTO inModel);

    }
}
