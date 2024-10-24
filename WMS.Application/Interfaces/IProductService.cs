using WMS.Application.DTOs.Results;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Interfaces
{
    public interface IProductService : IBaseService<Product, string>
    {
        Task<BaseResult> RecoverAsync(string id);
    }
}
