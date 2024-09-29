using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Organization;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Organization
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.Id).IsUnicode(false).HasMaxLength(10);
            builder.Property(p => p.WarehouseId).IsUnicode(false);
            builder.Property(p => p.IdentityNumber).IsUnicode(false).IsFixedLength(false);
            builder.HasOne(p=>p.Warehouse).WithMany().HasForeignKey(p => p.WarehouseId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
