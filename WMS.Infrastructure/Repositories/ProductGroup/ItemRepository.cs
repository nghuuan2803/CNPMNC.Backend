using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Domain.Abstracts.ProductGroup;
using WMS.Domain.Entities.ProductGroup;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.ProductGroup
{
    public class ItemRepository : BaseRepository<Item, string>, IItemRepository
    {
        public ItemRepository(AppDbContext db) : base(db)
        {
        }
        public override async Task<Item> GetAsync(Expression<Func<Item, bool>> predicate)
        {
            return await _db.Items.Include(p => p.Product).Include(p => p.Warehouse).FirstOrDefaultAsync(predicate);
        }
    }
}
