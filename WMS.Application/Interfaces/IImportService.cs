using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Domain.Entities.Activities;

namespace WMS.Application.Interfaces
{
    public interface IImportService
    {
        Task<BaseResult<Import>> CreateAsync(Import model);

        Task<BaseResult> CancelAsync(string id);

        Task<BaseResult> DeleteAsync(string id);

        Task<BaseResult<Import>> FindByIdAsync(string id);

        Task<BaseResult<Import>> GetAsync(Expression<Func<Import, bool>> predicate);

        Task<BaseResult<IEnumerable<Import>>> GetListAsync(Expression<Func<Import, bool>> predicate = null!);

        Task<BaseResult<IEnumerable<Import>>> GetListAsync(int pageSize = 20, int pageNumber = 1, Expression<Func<Import, bool>> predicate = null!);
    }
}
