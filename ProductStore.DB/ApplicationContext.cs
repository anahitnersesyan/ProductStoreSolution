using Microsoft.EntityFrameworkCore;
using ProductStore.Core.DataModels;

namespace ProductStore.DB
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProduct> CustomerProducts { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}
