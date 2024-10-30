using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Domain.Abstracts.ProductGroup;
using WMS.Domain.Entities.ProductGroup;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.ProductGroup
{
    public class InventoryRepository : BaseRepository<Inventory, int>, IInventoryRepository
    {
        public InventoryRepository(AppDbContext db) : base(db)
        {
        }

        public override async Task<IEnumerable<Inventory>> GetListAsync(Expression<Func<Inventory, bool>> predicate = null!)
        {
            if (predicate == null)
            {
                return await _db.Inventories.Include(p => p.Warehouse).Include(p => p.Product).OrderBy(p=>p.WarehouseId).ToListAsync();
            }
            return await _db.Inventories.Where(predicate).Include(p => p.Warehouse).Include(p => p.Product).OrderBy(p => p.WarehouseId).ToListAsync();
        }
    }
}
