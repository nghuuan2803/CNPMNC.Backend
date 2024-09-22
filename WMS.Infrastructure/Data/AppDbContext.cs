using Microsoft.EntityFrameworkCore;
using WMS.Domain.Entities.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }
        //Auth
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        //Product group
        public DbSet<Category> Categories { get; set; } //1
        public DbSet<Brand> Brands { get; set; } //2
        public DbSet<Suplier> Supliers { get; set; } //3
        public DbSet<Origin> Origins { get; set; } //4
        public DbSet<Product> Products { get; set; } //5
        public DbSet<Batch> Batches { get; set; } //6

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
