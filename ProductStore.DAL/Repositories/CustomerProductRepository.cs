using ProductStore.Core.DataModels;
using ProductStore.Core.Interfaces.IRepositories;
using ProductStore.DB;


namespace ProductStore.DAL.Repositories
{
    public class CustomerProductRepository : BaseRepository<CustomerProduct>, ICustomerProductRepository
    {
        public CustomerProductRepository(ApplicationContext applcationContext)
            : base(applcationContext)
        {
        }       
    }
}
