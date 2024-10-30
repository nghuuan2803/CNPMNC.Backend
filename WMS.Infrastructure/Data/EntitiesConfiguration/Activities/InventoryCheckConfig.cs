using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Activities;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Activities
{
    public class InventoryCheckConfig : IEntityTypeConfiguration<InventoryCheck>
    {
        public void Configure(EntityTypeBuilder<InventoryCheck> builder)
        {
            builder.Property(p => p.WarehouseId).IsUnicode(false);
            builder.Property(p => p.ManagerId).IsUnicode(false);

            builder.HasOne(p => p.Manager).WithMany().HasForeignKey(p => p.ManagerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Assignee).WithMany().HasForeignKey(p => p.AssigneeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Warehouse).WithMany().HasForeignKey(p => p.WarehouseId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
