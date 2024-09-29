using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Domain.Abstracts.ProductRepo;
using WMS.Domain.Entities.ProductInfo;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.ProductData
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext db) : base(db) { }

        public override async Task<IEnumerable<Category>> GetListAsync(Expression<Func<Category, bool>> predicate)
        {
            if (predicate == null)
                return await _db.Categories.Include(i => i.Products).ToListAsync();
            return await _db.Categories.Where(predicate).Include(i => i.Products).ToListAsync();
        }
    }
}
