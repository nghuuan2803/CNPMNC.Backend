using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Entities.Activities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Activities
{
    public class ImportRepository : BaseRepository<Import, string>, IImportRepository
    {
        public ImportRepository(AppDbContext db) : base(db)
        {
        }
        public async override Task<IEnumerable<Import>> GetListAsync(Expression<Func<Import, bool>> predicate = null!)
        {
            if (predicate == null)
            {
                return await _db.Imports
                    .Include(p => p.Suplier)
                    .Include(p => p.Manager)
                    .Include(p => p.Warehouse)
                    .OrderByDescending(p=>p.CreatedOn)
                    .ToListAsync();
            }
            return await _db.Imports.Where(predicate)
                    .Include(p => p.Suplier)
                    .Include(p => p.Manager)
                    .Include(p => p.Warehouse)
                    .OrderByDescending(p=>p.CreatedOn)
                    .ToListAsync();
        }
        public override async Task<Import> GetAsync(Expression<Func<Import, bool>> predicate)
        {
            return await _db.Imports
                .Include(p => p.Suplier)
                .Include(p => p.Manager)
                .Include(p => p.Warehouse)
                .Include(p => p.Items).ThenInclude(p=>p.Product)
                .SingleOrDefaultAsync(predicate);
        }
        public async override Task<Import> FindAsync(string id)
        {
            return await _db.Imports.FindAsync(id);
        }
    }
}
