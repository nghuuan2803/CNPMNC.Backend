using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.Authentication;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Auth
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Id).IsUnicode(false).HasMaxLength(40);
            builder.Property(p => p.UserName).IsUnicode(false).HasMaxLength(20);
            builder.Property(p => p.Email).IsUnicode(false).HasMaxLength(30);

            builder.Property(p => p.NormalizedUserName).IsUnicode(false).HasMaxLength(20);
            builder.Property(p => p.NormalizedEmail).IsUnicode(false).HasMaxLength(30);

            builder.Property(p => p.EmployeeId).IsUnicode(false);
            builder.HasOne(p=>p.Employee).WithOne().HasForeignKey<User>(p=>p.EmployeeId);
            builder.HasOne(p=>p.Agency).WithOne().HasForeignKey<User>(p=>p.AgencyId);
        }
    }
}
