using Web.Data.Repository;

namespace Web.Data.Services
{
    public interface ICrudService<T> : ICrudRepository<T>
      where T : BaseEntity
    {
    }
}
