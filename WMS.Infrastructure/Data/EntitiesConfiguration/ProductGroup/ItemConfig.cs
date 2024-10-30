using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.ProductGroup;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.ProductGroup
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne(p=>p.Warehouse).WithMany().HasForeignKey(p=>p.WarehouseId);
            builder.HasOne(p=>p.Product).WithMany().HasForeignKey(p=>p.ProductId);
        }
    }
}
