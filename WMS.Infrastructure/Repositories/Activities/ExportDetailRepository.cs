using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Entities.Activities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Activities
{
    public class ExportDetailRepository : BaseRepository<ExportDetail, int>, IExportDetailRepository
    {
        public ExportDetailRepository(AppDbContext db) : base(db)
        {
        }
    }
}
