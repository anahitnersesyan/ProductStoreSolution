using ProductStore.Core.DataModels;
using ProductStore.Core.Interfaces.IRepositories;
using ProductStore.DB;

namespace ProductStore.DAL.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {

        }
    }
}
