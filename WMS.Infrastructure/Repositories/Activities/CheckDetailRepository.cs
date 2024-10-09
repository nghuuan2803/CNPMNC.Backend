using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Entities.Activities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Activities
{
    public class CheckDetailRepository : BaseRepository<CheckDetail, int>, ICheckDetailRepository
    {
        public CheckDetailRepository(AppDbContext db) : base(db)
        {
        }
    }
}
