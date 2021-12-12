namespace ProductStore.Shared.DTOs.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public int SectionId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Cost { get; set; }
        public int Price { get; set; }
    }
}
