using WMS.Application.DTOs.Requests;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Entities.ProductGroup;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllAsync();
        Task<IEnumerable<Inventory>> GetAsync(string productId);
        Task<IEnumerable<Product>> GetProductsAsync(string warehouseId);
        Task<Merge> MergeAsync(MergeInventoryRequest request);
        Task<IEnumerable<Merge>> GetMergeHistoryAsync();
        Task<Merge> GetMergeAsync(int id);
        Task<bool> CancelMergeAsync(Merge model);

    }
}
