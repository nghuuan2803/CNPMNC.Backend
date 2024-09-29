using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Organization;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Organization
{
    public class AgencyConfig : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {

        }
    }
}
