using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Auth
{
    public class UserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.Property(p => p.UserId).IsUnicode(false).HasMaxLength(40);
            builder.Property(p => p.RoleId).IsUnicode(false).HasMaxLength(40);
        }
    }
}
