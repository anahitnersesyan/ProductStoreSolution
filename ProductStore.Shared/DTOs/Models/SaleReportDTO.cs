using System;

namespace ProductStore.Shared.DTOs.Models
{
    public class SaleReportDTO
    {
        public DateTimeOffset Date { get; set; }
        public int SectionId { get; set; }
        public string BarCode { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int Income { get; set; }
    }
}
