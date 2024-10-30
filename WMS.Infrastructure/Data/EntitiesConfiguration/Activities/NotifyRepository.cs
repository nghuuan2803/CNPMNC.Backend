using WMS.Domain.Abstracts.Activities;
using WMS.Domain.Entities.Activities;
using WMS.Infrastructure.Repositories;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Activities
{
    public class NotifyRepository : BaseRepository<Notification, int>, INotifiyRepository
    {
        public NotifyRepository(AppDbContext db) : base(db)
        {
        }
    }
}
