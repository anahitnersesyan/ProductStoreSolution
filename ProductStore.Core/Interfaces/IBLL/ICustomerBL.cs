using ProductStore.Shared.DTOs;
using System.Threading.Tasks;

namespace ProductStore.Core.Interfaces.IBLL
{
    public interface ICustomerBL
    {
        Task<AddCustomerOutDTO> AddCustomerAsync(AddCustomerInDTO inModel);
        Task<SellProductOutDTO> SellProductToCustomerAsync(SellProductInDTO inModel);
        Task<ReportSalesOutDTO> ReportSalesAsync(ReportSalesInDTO inModel);
        Task<ReportCustomersOutDTO> ReportCustomersAsync(ReportCustomersInDTO inModel);
    }
}
