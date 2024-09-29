using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Locations;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Location
{
    public class WarehouseConfig : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(5).IsUnicode(false);
            builder.Property(p=>p.ManagerId).IsUnicode(false);
            builder.HasOne(p=>p.Manager).WithOne().HasForeignKey<Warehouse>(p=>p.ManagerId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.Stocks).WithOne(c => c.Warehouse).HasForeignKey(c => c.WarehouseId);
        }
    }
}
