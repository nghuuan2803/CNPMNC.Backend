using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Interfaces
{
    public interface IBaseService<TEntity,TKey> : IDisposable
        where TEntity : class
    {
        Task<BaseResult<TEntity>> AddAsync(TEntity model);
        Task<BaseResult<IEnumerable<TEntity>>> AddMultipleAsync(IEnumerable<TEntity> models);
        Task<BaseResult> UpdateAsync(TEntity model);
        Task<BaseResult> DeleteAsync(TKey id);

        Task<BaseResult<TEntity>> FindAsync(TKey id);
        Task<BaseResult<IEnumerable<TEntity>>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null!);
    }
}
