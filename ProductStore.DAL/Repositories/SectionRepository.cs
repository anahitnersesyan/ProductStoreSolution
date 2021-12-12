using ProductStore.Core.DataModels;
using ProductStore.Core.Interfaces.IRepositories;
using ProductStore.DB;

namespace ProductStore.DAL.Repositories
{
    public class SectionRepository : BaseRepository<Section>, ISectionRepository
    {
        public SectionRepository(ApplicationContext applicationContext)
            :base(applicationContext)
        {

        }
    }
}
