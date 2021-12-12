using ProductStore.Shared.DTOs.Models;
using System.Collections.Generic;

namespace ProductStore.Shared.DTOs
{
    public class ReportSalesOutDTO : BaseOutDTO
    {
        public List<SaleReportDTO> Reports { get; set; }
    }
}
