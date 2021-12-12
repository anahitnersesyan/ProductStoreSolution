using System.Collections.Generic;

namespace ProductStore.Core.DataModels
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
