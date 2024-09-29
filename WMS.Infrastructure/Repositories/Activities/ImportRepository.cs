using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Entities.Activities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Activities
{
    public class ImportRepository : BaseRepository<Import, int>, IImportRepository
    {
        public ImportRepository(AppDbContext db) : base(db)
        {
        }

        public override async Task<Import> GetAsync(Expression<Func<Import, bool>> predicate)
        {
            return await _db.Imports.Where(predicate).Include(p => p.Items).SingleOrDefaultAsync();
        }
        public async override Task<Import> FindAsync(int id)
        {
            return await _db.Imports.Where(p => p.Id == id).Include(p => p.Items).SingleOrDefaultAsync();
        }
    }
}
