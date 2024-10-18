using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Enums;

namespace WMS.Application.Interfaces
{
    public interface IExportService
    {
        Task<BaseResult<Export>> CreateAsync(Export model);
        Task<BaseResult> UpdateAsync(Export model);
        Task<BaseResult> DeleteAsync(int id);
        Task<BaseResult> UpdateStateAsync(int id, ExportStatus status);

        Task<BaseResult<IEnumerable<Export>>> GetAllAsync(Expression<Func<Export,bool>> predicate = null!); //full information
        Task<BaseResult<IEnumerable<Export>>> GetListAsync(Expression<Func<Export,bool>> predicate = null!); //No Include dependency classes
        Task<BaseResult<Export>> GetAsync(Expression<Func<Export,bool>> predicate); //Full information
        Task<BaseResult<Export>> FindByIdAsync(int id); //No include dependency classes
    }
}
