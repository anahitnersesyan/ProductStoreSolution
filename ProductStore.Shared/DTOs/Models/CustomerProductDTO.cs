using System;

namespace ProductStore.Shared.DTOs.Models
{
    public class CustomerProductDTO
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public DateTimeOffset Date { get; set; }

        public int Count { get; set; }
    }
}
