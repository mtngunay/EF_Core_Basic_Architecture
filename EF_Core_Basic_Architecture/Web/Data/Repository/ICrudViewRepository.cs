namespace Web.Data.Repository
{
    public interface ICrudViewRepository<T> : IGenericViewRepository<T>
        where T : ViewEntity
    {
    }
}
