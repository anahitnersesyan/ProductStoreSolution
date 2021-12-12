using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductStore.Core.DataModels
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string BarCode { get; set; }

        [Required]
        public int SectionId { get; set; }
        public Section Section { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public int Price { get; set; }

        public ICollection<CustomerProduct> CustomerProducts { get; set; }
    }
}
