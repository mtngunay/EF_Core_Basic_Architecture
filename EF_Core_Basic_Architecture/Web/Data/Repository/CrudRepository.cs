namespace Web.Data.Repository
{
    public abstract class CrudRepository<TEntity> : GenericRepository<TEntity>, ICrudRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected CrudRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
