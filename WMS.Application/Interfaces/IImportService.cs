using System.Linq.Expressions;
using WMS.Application.DTOs.Requests.Activities;
using WMS.Application.DTOs.Results;
using WMS.Domain.Entities.Activities;

namespace WMS.Application.Interfaces
{
    public interface IImportService
    {
        Task<BaseResult<Import>> CreateAsync(Import model);

        Task<BaseResult<ImportDetail>> AddItemAsync(ImportDetail model);

        Task<BaseResult> UpdateAsync(Import model);

        Task<BaseResult> UpdateItemsAsync(ImportDetail item);

        Task<BaseResult> UpdateStatus(UpdateImportStatusRequest model);

        Task<BaseResult> CancelAsync(Import model);

        Task<BaseResult> DeleteAsync(int id);

        Task<BaseResult> DeleteItemAsync(ImportDetail model);

        Task<BaseResult<Import>> FindByIdAsync(int id);

        Task<BaseResult<Import>> GetAsync(Expression<Func<Import, bool>> predicate);

        Task<BaseResult<IEnumerable<Import>>> GetListAsync(Expression<Func<Import, bool>> predicate = null!);

        Task<BaseResult<IEnumerable<Import>>> GetListAsync(int pageSize = 20, int pageNumber = 1, Expression<Func<Import, bool>> predicate = null!);
    }
}
