using WMS.Domain.Entities.ProductInfo;

namespace WMS.Domain.Abstracts.ProductRepo
{
    public interface IProductRepository : IBaseRepository<Product, string>
    {
    }
}
