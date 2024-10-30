using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Entities.Activities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Activities
{
    public class MergeRepository : BaseRepository<Merge, int>, IMergeRepository
    {
        public MergeRepository(AppDbContext db) : base(db)
        {
        }

        public async override Task<IEnumerable<Merge>> GetListAsync(Expression<Func<Merge, bool>> predicate = null)
        {
            return await _db.Merges.Include(p => p.Product).Include(p => p.Src).Include(p => p.Dest).ToListAsync();
        }

        public async override Task<Merge> GetAsync(Expression<Func<Merge, bool>> predicate = null)
        {
            return await _db.Merges.Include(p => p.Product).Include(p => p.Src).Include(p => p.Dest).SingleOrDefaultAsync(predicate);
        }
    }
}
