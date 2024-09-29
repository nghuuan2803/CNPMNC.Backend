using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Activities;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Activities
{
    public class ExportDetailConfig : IEntityTypeConfiguration<ExportDetail>
    {
        public void Configure(EntityTypeBuilder<ExportDetail> builder)
        {
            builder.Property(p => p.WarehouseId).IsUnicode(false);

            //builder.HasOne(p => p.Export).WithMany().HasForeignKey(p => p.ExportId);

            builder.HasOne(p => p.Product).WithMany().HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Warehouse).WithMany().HasForeignKey(p => p.WarehouseId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
