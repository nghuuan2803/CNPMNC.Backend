using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Activities;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Activities
{
    public class ExportConfig : IEntityTypeConfiguration<Export>
    {
        public void Configure(EntityTypeBuilder<Export> builder)
        {
            builder.Property(p => p.ManagerId).IsUnicode(false);
            builder.HasOne(p => p.Manager).WithMany().HasForeignKey(p => p.ManagerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Agency).WithMany().HasForeignKey(p => p.AgencyId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Items).WithOne(c => c.Export).HasForeignKey(c => c.ExportId);
        }
    }
}
