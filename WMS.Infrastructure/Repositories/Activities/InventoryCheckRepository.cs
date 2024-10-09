using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Entities.Activities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Activities
{
    public class InventoryCheckRepository : BaseRepository<InventoryCheck, int>, IInventoryCheckRepository
    {
        public InventoryCheckRepository(AppDbContext db) : base(db)
        {
        }
    }
}
