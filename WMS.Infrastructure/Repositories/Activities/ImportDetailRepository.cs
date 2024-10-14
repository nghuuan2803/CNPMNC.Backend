using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Entities.Activities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Activities
{
    public class ImportDetailRepository : BaseRepository<ImportDetail, int>, IImportDetailRepository
    {
        public ImportDetailRepository(AppDbContext db) : base(db)
        {
        }

        public void UpdateMultiple(IEnumerable<ImportDetail> items)
        {
            _db.UpdateRange(items);
        }
    }
}
