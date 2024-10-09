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
using Microsoft.AspNetCore.Identity;

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
        public DbSet<Inventory> Inventories { get; set; } //8
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
            SeedData(builder);
        }
        private void SeedData(ModelBuilder builder)
        {
            var admin = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "nghuuan2803@gmail.com",
                NormalizedEmail = "nghuuan2803@gmail.com".ToUpper(),
                AccessFailedCount = 0
            };
            var superManager = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "supermanager",
                NormalizedUserName = "supermanager".ToUpper(),
                Email = "anhuu2803@gmail.com",
                NormalizedEmail = "anhuu2803@gmail.com".ToUpper(),
                AccessFailedCount = 0
            };
            var branchManager = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "branchmanager",
                NormalizedUserName = "branchmanager".ToUpper(),
                Email = "huuann28@gmail.com",
                NormalizedEmail = "huuann28@gmail.com".ToUpper(),
                AccessFailedCount = 0
            };
            var agency = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "agency",
                NormalizedUserName = "agency".ToUpper(),
                Email = "an2831998@gmail.com",
                NormalizedEmail = "an2831998@gmail.com".ToUpper(),
                AccessFailedCount = 0
            };
            var accountant = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "accountant",
                NormalizedUserName = "accountant".ToUpper(),
                Email = "abcde@gmail.com",
                NormalizedEmail = "abcde@gmail.com".ToUpper(),
                AccessFailedCount = 0
            };
            var passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "123123");
            superManager.PasswordHash = passwordHasher.HashPassword(superManager, "123123");
            branchManager.PasswordHash = passwordHasher.HashPassword(branchManager, "123123");
            agency.PasswordHash = passwordHasher.HashPassword(agency, "123123");
            accountant.PasswordHash = passwordHasher.HashPassword(accountant, "123123");

            builder.Entity<User>().HasData(admin);
            builder.Entity<User>().HasData(superManager);
            builder.Entity<User>().HasData(branchManager);
            builder.Entity<User>().HasData(agency);
            builder.Entity<User>().HasData(accountant);

            var admRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "admin".ToUpper(),
            };
            var managerRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "supermanager",
                NormalizedName = "supermanager".ToUpper(),
            };
            var agencyRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "agency",
                NormalizedName = "agency".ToUpper(),
            };

            var brmanagerRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "branchManager",
                NormalizedName = "branchManager".ToUpper(),
            };
            var accountantRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "accountant",
                NormalizedName = "accountant".ToUpper(),
            };

            builder.Entity<IdentityRole>().HasData(admRole);
            builder.Entity<IdentityRole>().HasData(managerRole);
            builder.Entity<IdentityRole>().HasData(agencyRole);
            builder.Entity<IdentityRole>().HasData(brmanagerRole);
            builder.Entity<IdentityRole>().HasData(accountantRole);

            var adminRole = new IdentityUserRole<string>
            {
                RoleId = admRole.Id,
                UserId = admin.Id
            };
            var mngRole = new IdentityUserRole<string>
            {
                RoleId = managerRole.Id,
                UserId = superManager.Id
            };
            var brmngRole = new IdentityUserRole<string>
            {
                RoleId = brmanagerRole.Id,
                UserId = branchManager.Id
            };
            var agcRole = new IdentityUserRole<string>
            {
                RoleId = agencyRole.Id,
                UserId = agency.Id
            };
            var actRole = new IdentityUserRole<string>
            {
                RoleId = accountantRole.Id,
                UserId = accountant.Id
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRole);
            builder.Entity<IdentityUserRole<string>>().HasData(mngRole);
            builder.Entity<IdentityUserRole<string>>().HasData(brmngRole);
            builder.Entity<IdentityUserRole<string>>().HasData(agcRole);
            builder.Entity<IdentityUserRole<string>>().HasData(actRole);
        }
    }
}
