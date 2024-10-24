using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Activities;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Activities
{
    public class MergeConfig : IEntityTypeConfiguration<Merge>
    {
        public void Configure(EntityTypeBuilder<Merge> builder)
        {
            builder.HasOne(p=>p.Src).WithMany().HasForeignKey(p=>p.From).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p=>p.Dest).WithMany().HasForeignKey(p=>p.To).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p=>p.Manager).WithMany().HasForeignKey(p=>p.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=>p.Product).WithMany().HasForeignKey(p=>p.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
