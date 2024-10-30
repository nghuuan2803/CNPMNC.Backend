using Microsoft.EntityFrameworkCore;
using WMS.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WMS.Domain.Entities.ProductInfo;
using WMS.Domain.Entities.Locations;
using WMS.Domain.Entities.Activities;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.ProductGroup;
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
        //Organization
        public DbSet<Employee> Employees { get; set; } //16
        public DbSet<Agency> Agencies { get; set; } //17

        public DbSet<Item> Items { get; set; } //18
        public DbSet<Merge> Merges { get; set; } //19
        public DbSet<Notification> Notifications { get; set; } //19

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
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                AccessFailedCount = 0
            };
            var manager = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "manager",
                NormalizedUserName = "manager".ToUpper(),
                Email = "manager@gmail.com",
                NormalizedEmail = "manager@gmail.com".ToUpper(),
                AccessFailedCount = 0
            };
            var keeper = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "keeper",
                NormalizedUserName = "keeper".ToUpper(),
                Email = "keeper@gmail.com",
                NormalizedEmail = "keeper@gmail.com".ToUpper(),
                AccessFailedCount = 0
            };
            var agency = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "agency1",
                NormalizedUserName = "agency1".ToUpper(),
                Email = "agency1@gmail.com",
                NormalizedEmail = "agency1@gmail.com".ToUpper(),
                AccessFailedCount = 0
            };
            var accountant = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "accountant",
                NormalizedUserName = "accountant".ToUpper(),
                Email = "accountant@gmail.com",
                NormalizedEmail = "accountant@gmail.com".ToUpper(),
                AccessFailedCount = 0
            };
            var passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "123123");
            manager.PasswordHash = passwordHasher.HashPassword(manager, "123123");
            keeper.PasswordHash = passwordHasher.HashPassword(keeper, "123123");
            agency.PasswordHash = passwordHasher.HashPassword(agency, "123123");
            accountant.PasswordHash = passwordHasher.HashPassword(accountant, "123123");

            builder.Entity<User>().HasData(admin);
            builder.Entity<User>().HasData(manager);
            builder.Entity<User>().HasData(keeper);
            builder.Entity<User>().HasData(agency);
            builder.Entity<User>().HasData(accountant);

            var adminRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "admin".ToUpper(),
            };
            var managerRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "manager",
                NormalizedName = "manager".ToUpper(),
            };
            var agencyRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "agency",
                NormalizedName = "agency".ToUpper(),
            };

            var keeperRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "keeper",
                NormalizedName = "keeper".ToUpper(),
            };
            var accountantRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "accountant",
                NormalizedName = "accountant".ToUpper(),
            };

            builder.Entity<IdentityRole>().HasData(adminRole);
            builder.Entity<IdentityRole>().HasData(managerRole);
            builder.Entity<IdentityRole>().HasData(agencyRole);
            builder.Entity<IdentityRole>().HasData(keeperRole);
            builder.Entity<IdentityRole>().HasData(accountantRole);

            var admRole = new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = admin.Id
            };
            var mngRole = new IdentityUserRole<string>
            {
                RoleId = managerRole.Id,
                UserId = manager.Id
            };
            var kpRole = new IdentityUserRole<string>
            {
                RoleId = keeperRole.Id,
                UserId = keeper.Id
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
            builder.Entity<IdentityUserRole<string>>().HasData(admRole);
            builder.Entity<IdentityUserRole<string>>().HasData(mngRole);
            builder.Entity<IdentityUserRole<string>>().HasData(kpRole);
            builder.Entity<IdentityUserRole<string>>().HasData(agcRole);
            builder.Entity<IdentityUserRole<string>>().HasData(actRole);
        }
    }
}
