using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Domain.Abstracts.Locations;
using WMS.Domain.Entities.Locations;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Loaction
{
    public class WarehouseRepository : BaseRepository<Warehouse, string>, IWarehouseRepository
    {
        public WarehouseRepository(AppDbContext db) : base(db)
        {
        }
        public override async Task<IEnumerable<Warehouse>> GetListAsync(Expression<Func<Warehouse, bool>> predicate = null!)
        {
            if (predicate == null)
                return await _db.Warehouses.Include(p => p.Manager).ToListAsync();
            return await _db.Warehouses.Where(predicate).Include(p => p.Manager).ToListAsync();
        }
        public async override Task<Warehouse> GetAsync(Expression<Func<Warehouse, bool>> predicate)
        {
            return await _db.Warehouses.Include(p => p.Manager).SingleOrDefaultAsync(predicate);
        }
    }
}
