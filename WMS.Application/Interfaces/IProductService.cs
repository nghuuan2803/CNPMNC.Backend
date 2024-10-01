using WMS.Application.DTOs.Results;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Interfaces
{
    public interface IProductService : IBaseService<Product, int>
    {
        Task<BaseResult> RecoverAsync(int id);
    }
}
