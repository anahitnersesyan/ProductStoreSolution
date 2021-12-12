using Microsoft.EntityFrameworkCore;
using ProductStore.Core.DataModels;
using ProductStore.Core.Interfaces.IRepositories;
using ProductStore.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductStore.DAL.Repositories
{
    public class CustomerProductRepository : BaseRepository<CustomerProduct>, ICustomerProductRepository
    {
        public CustomerProductRepository(ApplicationContext applcationContext)
            : base(applcationContext)
        {
        }

        public override async Task<ICollection<CustomerProduct>> FindAllAsync(Expression<Func<CustomerProduct, bool>> expression)
        {
            var customerProducts = await _appContext.CustomerProducts                
                .Include(item => item.Product)
                .ThenInclude(item => item.Section)
                .Include(item => item.Customer).ToListAsync();

            var filteredCustomerProducts = customerProducts.Where(expression.Compile()).ToList();

            return filteredCustomerProducts;
        }

    }
}
