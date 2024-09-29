using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.Auth
{
    public class UserClaimConfig : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder.Property(p => p.Id).IsUnicode(false).HasMaxLength(40);
            builder.Property(p => p.UserId).IsUnicode(false).HasMaxLength(40);
        }
    }
}
