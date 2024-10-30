using System.Linq.Expressions;
using WMS.Application.DTOs.Results;
using WMS.Domain.Entities.Activities;

namespace WMS.Application.Interfaces
{
    public interface IExportService
    {
        Task<BaseResult<Export>> ApprovalOrderAsync(Export model);//duyệt đơn hàng từ đại lý

        Task<BaseResult> RefuseOrderAsync(int id, string? employeeId = null);//duyệt đơn hàng từ đại lý

        Task<BaseResult<IEnumerable<Export>>> GetAllAsync(Expression<Func<Export,bool>> predicate = null!); //full information
        Task<BaseResult<IEnumerable<Export>>> GetListAsync(Expression<Func<Export,bool>> predicate = null!); //No Include dependency classes
        Task<BaseResult<Export>> GetAsync(Expression<Func<Export,bool>> predicate); //Full information
        Task<BaseResult<Export>> GetAsync(int id); //No include dependency classes
        Task<BaseResult> CancelAsync(int id, string? employeeId = null); //No include dependency classes
        Task<BaseResult> CompleteAsync(int id, string? employeeId = null); //No include dependency classes

    }
}
