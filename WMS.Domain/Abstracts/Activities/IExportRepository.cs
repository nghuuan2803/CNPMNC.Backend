using System.Linq.Expressions;
using WMS.Domain.Entities.Activities;

namespace WMS.Domain.Abstracts.Activities
{
    public interface IExportRepository : IBaseRepository<Export,int>
    {
        Task<IEnumerable<Export>> GetAllAsync(Expression<Func<Export, bool>> predicate = null!);
    }
}
