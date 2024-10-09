using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.ProductGroup;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.ProductGroup
{
    public class StockProductConfig : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.Property(p => p.WarehouseId).IsUnicode(false);
            //builder.HasOne(p=>p.Product).WithMany().HasForeignKey(p=>p.ProductId);
            //builder.HasOne(p=>p.Warehouse).WithMany().HasForeignKey(p=>p.WarehouseId);
        }
    }
}
