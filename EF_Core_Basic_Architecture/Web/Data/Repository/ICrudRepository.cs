namespace Web.Data.Repository
{
    public interface ICrudRepository<T> : IGenericRepository<T>
     where T : BaseEntity
    {
    }
}
