using System.Linq.Expressions;

namespace Web.Data.Repository
{
    public interface IGenericViewRepository<TEntity> where TEntity : ViewEntity
    {//Get Entity
        TEntity Get(int id, System.Security.Claims.ClaimsPrincipal user = null);
        Task<TEntity> GetAsync(int id, System.Security.Claims.ClaimsPrincipal user = null);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null, System.Security.Claims.ClaimsPrincipal user = null);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null, System.Security.Claims.ClaimsPrincipal user = null);

        //Get Entities (List)
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, bool isDeletedCache = false, System.Security.Claims.ClaimsPrincipal user = null, CancellationToken cancellationToken = default);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, bool isDeletedCache = false, System.Security.Claims.ClaimsPrincipal user = null);
        List<TEntity> GetAllAsNoTracking(Expression<Func<TEntity, bool>> predicate = null, bool isDeletedCache = false, System.Security.Claims.ClaimsPrincipal user = null);
        List<TEntity> GetAllPaginationAsNoTracking(Expression<Func<TEntity, bool>> predicate = null, bool isDeletedCache = false, System.Security.Claims.ClaimsPrincipal user = null, int pageNumber = 1, int pageSize = 10);
        int Count();
        int Count(Expression<Func<TEntity, bool>> predicate = null);
    }
}
