using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Entities.Activities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Activities
{
    public class ExportRepository : BaseRepository<Export, int>, IExportRepository
    {
        public ExportRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Export>> GetAllAsync(Expression<Func<Export, bool>> predicate = null!)
        {
            if (predicate == null)
            {
                return await _db.Exports.Include(p => p.Agency).Include(p => p.Manager).Include(p => p.Items).ThenInclude(p => p.Product).Include(p => p.Items).ThenInclude(p => p.Warehouse).ToListAsync();
            }
            return await _db.Exports.Where(predicate).Include(p => p.Agency).Include(p => p.Manager).Include(p => p.Items).ThenInclude(p => p.Product).Include(p => p.Items).ThenInclude(p => p.Warehouse).ToListAsync();
        }

        public override async Task<Export> GetAsync(Expression<Func<Export, bool>> predicate = null!)
        {
            Export data;
            if (predicate == null)
            {
                data = await _db.Exports.Include(p => p.Agency)
                    .Include(p => p.Manager)
                    .Include(p => p.Items).ThenInclude(p => p.Product)
                    .Include(p => p.Items).ThenInclude(p => p.Warehouse)
                    .SingleOrDefaultAsync();
            }
            else
            {
                data = await _db.Exports.Where(predicate).Include(p => p.Agency)
                .Include(p => p.Manager)
                .Include(p => p.Items).ThenInclude(p => p.Product)
                .Include(p => p.Items).ThenInclude(p => p.Warehouse).SingleOrDefaultAsync();
            }
            return data;
        }
    }
}
