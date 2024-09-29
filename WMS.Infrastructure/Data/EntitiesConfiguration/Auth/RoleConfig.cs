using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Auth
{
    public class RoleConfig : IEntityTypeConfiguration<IdentityRole>
    {

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.Property(p => p.Id).IsUnicode(false).HasMaxLength(40);
            builder.Property(p => p.Name).IsUnicode(false).HasMaxLength(20);
            builder.Property(p => p.NormalizedName).IsUnicode(false).HasMaxLength(20);
        }
    }
}
