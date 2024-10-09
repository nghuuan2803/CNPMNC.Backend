using WMS.Domain.Abstracts.Locations;
using WMS.Domain.Entities.Locations;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Loaction
{
    public class WarehouseRepository : BaseRepository<Warehouse, string>, IWarehouseRepository
    {
        public WarehouseRepository(AppDbContext db) : base(db)
        {
        }
    }
}
