using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Activities;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Activities
{
    public class ImportDetailConfig : IEntityTypeConfiguration<ImportDetail>
    {
        public void Configure(EntityTypeBuilder<ImportDetail> builder)
        {
            //builder.HasOne(p=>p.Import).WithMany().HasForeignKey(p=>p.ImportId);
            builder.HasOne(p=>p.Product).WithMany().HasForeignKey(p=>p.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
