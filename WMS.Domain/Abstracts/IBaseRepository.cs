using System.Linq.Expressions;

namespace WMS.Domain.Abstracts
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task AddMultipleAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null!);
        Task<TEntity> FindAsync(TKey id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        void Detach(TEntity entity);
    }
}
