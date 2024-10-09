using WMS.Domain.Abstracts.Organization;
using WMS.Domain.Entities.Organization;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Organization
{
    public class EmployeeRepository : BaseRepository<Employee, string>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext db) : base(db)
        {
        }
    }
}
