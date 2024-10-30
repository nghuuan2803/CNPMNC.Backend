using WMS.Application.DTOs.Results;
using WMS.Domain.Entities.Activities;

namespace WMS.Application.Interfaces
{
    public interface IOrderService
    {
        Task<BaseResult<Export>> CreateAsync(Export model);
        Task<BaseResult> CancelAsync(int id);
        Task<BaseResult<IEnumerable<Export>>> HistoryListAsync(int agencyId);
        Task<BaseResult<IEnumerable<Export>>> GetListAsync();
        Task<BaseResult<Export>> GetDetailAsync(int id);
        Task<BaseResult<Export>> GetDetailAsync(string invoiceId);
    }
}
