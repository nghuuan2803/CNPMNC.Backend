using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
