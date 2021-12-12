using System;
using System.ComponentModel.DataAnnotations;

namespace ProductStore.Shared.DTOs
{
    public class ReportSalesInDTO
    {
        [Required]
        public DateTimeOffset StartDate { get; set; }

        [Required]
        public DateTimeOffset EndDate { get; set; }
    }
}
