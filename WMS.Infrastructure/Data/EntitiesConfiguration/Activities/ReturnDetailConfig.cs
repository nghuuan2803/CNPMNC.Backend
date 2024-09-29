using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Activities;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Activities
{
    public class ReturnDetailConfig : IEntityTypeConfiguration<ReturnDetail>
    {
        public void Configure(EntityTypeBuilder<ReturnDetail> builder)
        {
            //builder.HasOne(p => p.Return).WithMany().HasForeignKey(p => p.ReturnId);
            builder.HasOne(p => p.Product).WithMany().HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
