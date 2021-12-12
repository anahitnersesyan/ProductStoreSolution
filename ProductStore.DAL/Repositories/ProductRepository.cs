using ProductStore.Core.DataModels;
using ProductStore.Core.Interfaces.IRepositories;
using ProductStore.DB;

namespace ProductStore.DAL.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {

        }
    }
}
