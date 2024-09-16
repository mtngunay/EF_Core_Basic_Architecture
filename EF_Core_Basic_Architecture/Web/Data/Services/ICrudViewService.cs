using Web.Data.Repository;

namespace Web.Data.Services
{
    public interface ICrudViewService<T> : ICrudViewRepository<T>
      where T : ViewEntity
    {
    }
}
