using System;


namespace ProductStore.Shared.DTOs.Models
{
   public  class CustomerReportDTO
    {
        public DateTimeOffset Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Count { get; set; }
        public int Volume { get; set; }
    }
}
