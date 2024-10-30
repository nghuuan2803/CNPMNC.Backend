using WMS.Domain.Entities.Activities;

namespace WMS.Application.Interfaces
{
    public interface INotifyService : IBaseService<Notification,int>
    {
        Task<Notification> Checked(int id);
        Task<IEnumerable<Notification>> GetListAsync(string id);
    }
}
