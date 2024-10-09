using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Entities.Activities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Activities
{
    public class ReturnDetailRepository : BaseRepository<ReturnDetail, int>, IReturnDetailRepository
    {
        public ReturnDetailRepository(AppDbContext db) : base(db)
        {
        }
    }
}
