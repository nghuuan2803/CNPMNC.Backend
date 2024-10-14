using WMS.Domain.Entities.Activities;

namespace WMS.Domain.Abstracts.Activities
{
    public interface IImportDetailRepository : IBaseRepository<ImportDetail,int>
    {
        void UpdateMultiple(IEnumerable<ImportDetail> items);
    }
}
