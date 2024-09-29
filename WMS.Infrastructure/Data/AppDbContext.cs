using Microsoft.EntityFrameworkCore;
using WMS.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WMS.Domain.Entities.ProductInfo;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.ProductGroup;
using WMS.Infrastructure.Data.EntitiesConfiguration.Activities;
using WMS.Infrastructure.Data.EntitiesConfiguration.ProductGroup;
using WMS.Infrastructure.Data.EntitiesConfiguration.Location;
using WMS.Infrastructure.Data.EntitiesConfiguration.Organization;
using WMS.Infrastructure.Data.EntitiesConfiguration.Auth;

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
        //Location
        public DbSet<Warehouse> Warehouses { get; set; } //7
        public DbSet<StockProduct> StockProducts { get; set; } //8
        //Activities
        public DbSet<Import> Imports { get; set; } //9
        public DbSet<ImportDetail> ImportDetails { get; set; } //10
        public DbSet<Export> Exports { get; set; } //11
        public DbSet<ExportDetail> ExportDetails { get; set; } //12
        public DbSet<Return> Returns { get; set; } //13
        public DbSet<ReturnDetail> ReturnDetails { get; set; } //14
        public DbSet<InventoryCheck> InventoryChecks { get; set; } //15
        public DbSet<CheckDetail> CheckDetails { get; set; } //16
        //Organization
        public DbSet<Employee> Employees { get; set; } //17
        public DbSet<Agency> Agencies { get; set; } //18

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            //builder.ApplyConfiguration(new CategoryConfig());
            //builder.ApplyConfiguration(new BrandConfig());
            //builder.ApplyConfiguration(new SuplierConfig());
            //builder.ApplyConfiguration(new OriginConfig());
            //builder.ApplyConfiguration(new ProductConfig());
            //builder.ApplyConfiguration(new BatchConfig());
            //builder.ApplyConfiguration(new WarehouseConfig());
            //builder.ApplyConfiguration(new StockProductConfig());
            //builder.ApplyConfiguration(new ImportConfig());
            //builder.ApplyConfiguration(new ImportDetailConfig());
            //builder.ApplyConfiguration(new ExportConfig());
            //builder.ApplyConfiguration(new ExportDetailConfig());
            //builder.ApplyConfiguration(new InventoryCheckConfig());
            //builder.ApplyConfiguration(new CheckDetailConfig());
            //builder.ApplyConfiguration(new EmployeeConfig());
            //builder.ApplyConfiguration(new AgencyConfig());

            //builder.ApplyConfiguration(new ReturnConfig());
            //builder.ApplyConfiguration(new ReturnDetailConfig());
            //builder.ApplyConfiguration(new UserConfig());
        }
    }
}
