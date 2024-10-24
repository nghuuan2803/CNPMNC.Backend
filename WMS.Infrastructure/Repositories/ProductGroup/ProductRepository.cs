using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Domain.Abstracts.ProductRepo;
using WMS.Domain.Entities.ProductInfo;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.ProductData
{
    public class ProductRepository : BaseRepository<Product, string>, IProductRepository
    {
        public ProductRepository(AppDbContext db) : base(db)
        {
        }
        public async override Task<IEnumerable<Product>> GetListAsync(Expression<Func<Product, bool>> predicate = null!)
        {
            if (predicate == null)
            {
                return await _db.Products.Include(p => p.Brand).Include(p => p.Category).ToListAsync();
            }
            return await _db.Products.Where(predicate).Include(p => p.Brand).Include(p => p.Category).ToListAsync();
        }
    }
}
