using WMS.Domain.Abstracts.Organization;
using WMS.Domain.Entities.Organization;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.Organization
{
    public class AgencyRepository : BaseRepository<Agency, int>, IAgencyRepository
    {
        public AgencyRepository(AppDbContext db) : base(db)
        {
        }
    }
}
