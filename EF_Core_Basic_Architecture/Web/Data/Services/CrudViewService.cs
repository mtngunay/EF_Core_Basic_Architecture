using Web.Data.Repository;

namespace Web.Data.Services
{
    public class CrudViewService<T> : CrudViewRepository<T>, ICrudViewService<T>
       where T : ViewEntity
    {
        public CrudViewService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
