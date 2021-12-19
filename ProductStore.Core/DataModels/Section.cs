using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductStore.Core.DataModels
{
    public class Section
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
