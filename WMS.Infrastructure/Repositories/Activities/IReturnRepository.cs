using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Entities.Activities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Activities
{
    public class ReturnRepository : BaseRepository<Return, int>, IReturnRepository
    {
        public ReturnRepository(AppDbContext db) : base(db)
        {
        }
    }
}
