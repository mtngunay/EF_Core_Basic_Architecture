using Web.Data.Repository;

namespace Web.Data.Services
{
    public class CrudService<T> : CrudRepository<T>, ICrudService<T>
     where T : BaseEntity
    {
        public CrudService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}