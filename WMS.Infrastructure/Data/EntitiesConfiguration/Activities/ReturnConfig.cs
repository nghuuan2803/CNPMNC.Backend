using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Activities;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Activities
{
    public class ReturnConfig : IEntityTypeConfiguration<Return>
    {
        public void Configure(EntityTypeBuilder<Return> builder)
        {
            builder.Property(p => p.WarehouseId).IsUnicode(false);
            builder.Property(p => p.ManagerId).IsUnicode(false);
            builder.HasOne(p => p.Agency).WithMany().HasForeignKey(p => p.AgencyId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Manager).WithMany().HasForeignKey(p => p.ManagerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Warehouse).WithMany().HasForeignKey(p => p.WarehouseId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Export).WithMany().HasForeignKey(p => p.ExportId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Items).WithOne(c => c.Return).HasForeignKey(c => c.ReturnId);
        }
    }
}
