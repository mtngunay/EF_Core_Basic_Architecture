using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Web.Data.Repository
{
    public abstract class GenericViewRepository<TEntity> : IGenericViewRepository<TEntity> where TEntity : ViewEntity
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        private TEntity _responseData;

        public GenericViewRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #region Get
        public TEntity Get(int id, ClaimsPrincipal user = null)
        {
            return _applicationDbContext.Set<TEntity>().FirstOrDefault(x => x.IsActive == true && x.IsDeleted != true && x.Id == id);

            return _responseData;
        }
        public async Task<TEntity> GetAsync(int id, ClaimsPrincipal user = null)
        {
            return await _applicationDbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.IsActive == true && x.IsDeleted != true && x.Id == id) ?? null;
        }
        #endregion
        #region FirstOrDefault
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null, ClaimsPrincipal user = null)
        {
            return (predicate != null ? _applicationDbContext.Set<TEntity>().AsNoTracking().Where(x => x.IsActive == true && x.IsDeleted != true).FirstOrDefault(predicate) : _applicationDbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.IsActive == true && x.IsDeleted != true));
        }
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null, ClaimsPrincipal user = null)
        {
            return (predicate != null ? await _applicationDbContext.Set<TEntity>().AsNoTracking().Where(x => x.IsActive == true && x.IsDeleted != true).FirstOrDefaultAsync(predicate) : await _applicationDbContext.Set<TEntity>().AsNoTracking().Where(x => x.IsActive == true && x.IsDeleted != true).FirstOrDefaultAsync());

        }
        #endregion
        #region GetAll
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, bool isDeletedCache = false, ClaimsPrincipal user = null, CancellationToken cancellationToken = default)
        {
            var entity = _applicationDbContext.Set<TEntity>();

            return predicate != null ? await entity.Where(x => x.IsActive == true && x.IsDeleted != true)
                 .Where(predicate)
                 .OrderByDescending(x => x.CreateDate).ToListAsync(cancellationToken) : await entity.Where(x => x.IsActive == true && x.IsDeleted != true)
                 .OrderByDescending(x => x.CreateDate).ToListAsync(cancellationToken);

        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, bool isDeletedCache = false, ClaimsPrincipal user = null)
        {
            var entity = _applicationDbContext.Set<TEntity>();
            return predicate != null ? entity.Where(x => x.IsActive == true && x.IsDeleted != true)
            .Where(predicate)
            .OrderByDescending(x => x.CreateDate).ToList() : entity.Where(x => x.IsActive == true && x.IsDeleted != true)
            .OrderByDescending(x => x.CreateDate).ToList();

        }
        public List<TEntity> GetAllAsNoTracking(Expression<Func<TEntity, bool>> predicate, bool isDeletedCache = false, ClaimsPrincipal user = null)
        {
            var entity = _applicationDbContext.Set<TEntity>();

            return predicate != null ? entity.Where(x => x.IsActive == true && x.IsDeleted != true)
            .Where(predicate).OrderByDescending(x => x.CreateDate).ToList() : entity.Where(x => x.IsActive == true && x.IsDeleted != true)
            .OrderByDescending(x => x.CreateDate).ToList();

        }
        public List<TEntity> GetAllPaginationAsNoTracking(Expression<Func<TEntity, bool>> predicate = null, bool isDeletedCache = false, ClaimsPrincipal user = null, int pageNumber = 1, int pageSize = 10)
        {
            var entity = _applicationDbContext.Set<TEntity>();

            return predicate != null ? entity.Where(x => x.IsActive == true && x.IsDeleted != true)
            .Where(predicate).OrderByDescending(x => x.CreateDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList() : entity.Where(x => x.IsActive == true && x.IsDeleted != true)
            .OrderByDescending(x => x.CreateDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        #endregion
        public int Count()
        {
            return _applicationDbContext.Set<TEntity>().AsNoTracking().AsQueryable().Count();
        }
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate != null ? _applicationDbContext.Set<TEntity>().Count(predicate) : _applicationDbContext.Set<TEntity>().Count();
        }
       
    }
}
