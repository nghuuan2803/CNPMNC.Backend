using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Activities;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Activities
{
    public class ImportConfig : IEntityTypeConfiguration<Import>
    {
        public void Configure(EntityTypeBuilder<Import> builder)
        {
            builder.Property(p => p.Id).IsUnicode(false).HasMaxLength(36);
            builder.Property(p => p.OrderBy).IsUnicode(false);
            builder.Property(p => p.WarehouseId).IsUnicode(false);
            builder.HasOne(p=>p.Manager).WithMany().HasForeignKey(p=>p.OrderBy).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=>p.Suplier).WithMany().HasForeignKey(p=>p.SuplierId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=>p.Warehouse).WithMany().HasForeignKey(p=>p.WarehouseId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Items).WithOne(c => c.Import).HasForeignKey(c => c.ImportId);
        }
    }
}
