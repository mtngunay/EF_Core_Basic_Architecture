namespace Web.Data.Repository
{
    public abstract class CrudViewRepository<TEntity> : GenericViewRepository<TEntity>, ICrudViewRepository<TEntity>
         where TEntity : ViewEntity
    {
        public CrudViewRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
