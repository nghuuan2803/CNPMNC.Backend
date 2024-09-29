using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.ProductGroup
{
    public class BatchConfig : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(40).IsUnicode(false);
            builder.Property(p => p.OriginId).IsUnicode(false);

            builder.HasOne(p => p.Product).WithMany().HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Origin).WithMany().HasForeignKey(p => p.OriginId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Import).WithMany().HasForeignKey(p => p.ImportId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
