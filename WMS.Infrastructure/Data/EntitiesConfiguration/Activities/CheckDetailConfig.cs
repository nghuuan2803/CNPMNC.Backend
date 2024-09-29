using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Activities;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Activities
{
    public class CheckDetailConfig : IEntityTypeConfiguration<CheckDetail>
    {
        public void Configure(EntityTypeBuilder<CheckDetail> builder)
        {
            //builder.HasOne(p => p.InventoryCheck).WithMany().HasForeignKey(p => p.InventoryCheckId);

            builder.HasOne(p => p.Product).WithMany().HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
