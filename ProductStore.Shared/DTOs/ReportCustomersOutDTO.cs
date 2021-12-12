using ProductStore.Shared.DTOs.Models;
using System.Collections.Generic;

namespace ProductStore.Shared.DTOs
{
    public class ReportCustomersOutDTO : BaseOutDTO
    {
        public ReportCustomersOutDTO()
        {
            Reports = new List<CustomerReportDTO>();
        }
        public List<CustomerReportDTO> Reports { get; set; }
    }
}
