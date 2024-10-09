using WMS.Domain.Abstracts.ProductGroup;
using WMS.Domain.Entities.ProductGroup;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.ProductGroup
{
    public class InventoryRepository : BaseRepository<Inventory, int>, IInventoryRepository
    {
        public InventoryRepository(AppDbContext db) : base(db)
        {
        }
    }
}
