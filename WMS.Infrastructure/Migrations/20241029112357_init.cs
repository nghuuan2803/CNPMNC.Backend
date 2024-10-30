using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TotalPaid = table.Column<double>(type: "float", nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Origins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "varchar(40)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rfid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    ImportPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Photo = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", unicode: false, maxLength: 40, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    RoleId = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    AgencyId = table.Column<int>(type: "int", nullable: true),
                    Rfid = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(40)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ManufactureDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "varchar(10)", nullable: false),
                    OriginId = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    ImportId = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batches_Origins_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Batches_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    IdentityNumber = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rfid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseId = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rfid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ExportDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InvoiceImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exports_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exports_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CapacityStatus = table.Column<int>(type: "int", nullable: false),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ExportDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExportId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "varchar(10)", nullable: false),
                    WarehouseId = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportDetails_Exports_ExportId",
                        column: x => x.ExportId,
                        principalTable: "Exports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExportDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExportDetails_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Imports",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OrderBy = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SuplierId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    InvoiceImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckPassed = table.Column<bool>(type: "bit", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imports_Employees_OrderBy",
                        column: x => x.OrderBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Imports_Supliers_SuplierId",
                        column: x => x.SuplierId,
                        principalTable: "Supliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Imports_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "varchar(10)", nullable: false),
                    WarehouseId = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "varchar(10)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ActualQuantity = table.Column<int>(type: "int", nullable: false),
                    AssigneeId = table.Column<string>(type: "varchar(10)", nullable: true),
                    ManagerId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    WarehouseId = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryChecks_Employees_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryChecks_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryChecks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryChecks_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BatchId = table.Column<string>(type: "varchar(40)", nullable: true),
                    ProductId = table.Column<string>(type: "varchar(10)", nullable: false),
                    Exported = table.Column<bool>(type: "bit", nullable: false),
                    WarehouseId = table.Column<string>(type: "varchar(5)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rfid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Merges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    From = table.Column<string>(type: "varchar(5)", nullable: false),
                    To = table.Column<string>(type: "varchar(5)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(10)", nullable: false),
                    ProductId = table.Column<string>(type: "varchar(10)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merges_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Merges_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Merges_Warehouses_From",
                        column: x => x.From,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Merges_Warehouses_To",
                        column: x => x.To,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefundAmount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefundDate = table.Column<double>(type: "float", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    ExportId = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    WarehouseId = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Returns_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Returns_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Returns_Exports_ExportId",
                        column: x => x.ExportId,
                        principalTable: "Exports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Returns_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImportDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    ImportId = table.Column<string>(type: "varchar(36)", nullable: false),
                    ProductId = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportDetails_Imports_ImportId",
                        column: x => x.ImportId,
                        principalTable: "Imports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReturnDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RefundPrice = table.Column<double>(type: "float", nullable: false),
                    ReturnId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturnDetails_Returns_ReturnId",
                        column: x => x.ReturnId,
                        principalTable: "Returns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "424962f4-963a-45ca-ae2a-b3b59d2043e0", null, "keeper", "KEEPER" },
                    { "4871a311-e7c2-45ac-81fa-107f0d2a9715", null, "agency", "AGENCY" },
                    { "79ddcb7b-18b8-458f-8786-585397bcb2f4", null, "accountant", "ACCOUNTANT" },
                    { "8a971cbf-d7ee-41e3-a77f-d297820f57db", null, "manager", "MANAGER" },
                    { "cab07f4f-1baa-4317-9149-47af5e8c5b8a", null, "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AgencyId", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "EmployeeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rfid", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "34daefcc-2e8e-41b1-8ac7-b2675c73fd82", 0, null, "2ff4fb48-cac1-4176-b4c3-28aaf8018432", new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(4320), "manager@gmail.com", false, null, false, null, "MANAGER@GMAIL.COM", "MANAGER", "AQAAAAIAAYagAAAAEB8+0TB/Lb/xw0rfEk+W2hVOtT0h/eKoRXG0JAyC94O2lwcFV9gW6Yi4Gn+Rdxp4vg==", null, false, null, "8a301944-bffc-419e-ae6b-0a7607c339b9", false, "manager" },
                    { "8a780762-d101-4f56-a211-ffea5ee38ba1", 0, null, "fd0ce055-951e-4724-9c0a-d67c2faeda91", new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(4358), "accountant@gmail.com", false, null, false, null, "ACCOUNTANT@GMAIL.COM", "ACCOUNTANT", "AQAAAAIAAYagAAAAEMuqUKqOudHoiecgFMBB8Zc/pno8uri9h7q/Yz5hAYrUdP+5Z840v5DdAqpRVdJtqA==", null, false, null, "371c27a1-a7eb-4702-aa6f-e52116e2e9f0", false, "accountant" },
                    { "964da110-c58e-4712-8444-78431873c0f2", 0, null, "32c91b75-63af-4884-9767-afd63081f72c", new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(4348), "agency1@gmail.com", false, null, false, null, "AGENCY1@GMAIL.COM", "AGENCY1", "AQAAAAIAAYagAAAAEDVIvacK9g5j9a6voepFtFjg5O1d93VTDe3cx3Rxcgo4WnaufNRYdsFjIaVLZJ7FyQ==", null, false, null, "b888ce72-7991-4756-ac8a-e5eaefda9b06", false, "agency1" },
                    { "a55364a8-6367-42b6-b2f1-6d4cfa0adef2", 0, null, "99c5b975-fbd5-43fe-942e-e8824a80a0a9", new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(4216), "admin@gmail.com", false, null, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEKws54AQQ7+lJiTBXw7A8NFTyfHVRus8JSgFtPHdE+Of1wwF8OtbdanuPFpVe/F9XA==", null, false, null, "26c2857b-6c43-4958-ab8b-49421ddcc39d", false, "admin" },
                    { "e6ce47a8-5fcd-49a2-8913-f4b0b6e5c354", 0, null, "e740c2af-72a2-4f52-81ca-99b0e85aa97a", new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(4339), "keeper@gmail.com", false, null, false, null, "KEEPER@GMAIL.COM", "KEEPER", "AQAAAAIAAYagAAAAEHZlj4slvzM3/Qo6eaXvztARdihv9qKiNwayNGWXxo/0YpNy5EGZU1aUQK2toFz0GA==", null, false, null, "bf3e6231-211a-4682-b95d-545aaf928f52", false, "keeper" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sony" },
                    { 2, "Panasonic" },
                    { 3, "Sam Sung" },
                    { 4, "Apple" },
                    { 5, " Xiaomi" },
                    { 6, "Tosiba" },
                    { 7, "Aqua" },
                    { 8, "Senko" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ti vi" },
                    { 2, "Nồi cơm điện" },
                    { 3, "Máy lọc nước" },
                    { 4, "Tủ lạnh" },
                    { 5, "Máy giặt" },
                    { 6, "Điều hòa" },
                    { 7, "Quạt điện" },
                    { 8, "Bếp từ" }
                });

            migrationBuilder.InsertData(
                table: "Origins",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "cn", "Trung Quốc" },
                    { "fr", "Pháp" },
                    { "ger", "Đức" },
                    { "ja", "Nhật" },
                    { "kor", "Hàn Quốc" },
                    { "rus", "Nga" },
                    { "thai", "Thái Lan" },
                    { "uk", "Anh" },
                    { "us", "Mỹ" },
                    { "vn", "Việt nam" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "BrandId", "CategoryId", "CreatedBy", "CreatedOn", "Deleted", "Description", "Discontinued", "Height", "ImportPrice", "Length", "ModifiedBy", "ModifiedOn", "Name", "Photo", "Price", "QRcode", "Quantity", "Rfid", "Width" },
                values: new object[,]
                {
                    { "SP0001", null, null, null, null, new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1779), false, null, false, 1.0, 0.0, 1.0, null, null, "Sony Bravia QLED SQ101", null, 10000000.0, null, 0, null, 1.0 },
                    { "SP0002", null, null, null, null, new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1802), false, null, false, 1.0, 0.0, 1.0, null, null, "Sony Bravia OLED SN101", null, 15000000.0, null, 0, null, 1.0 },
                    { "SP0003", null, null, null, null, new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1804), false, null, false, 1.0, 0.0, 1.0, null, null, "Sam Sung QLED SSQ113", null, 12000000.0, null, 0, null, 1.0 },
                    { "SP0004", null, null, null, null, new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1806), false, null, false, 1.0, 0.0, 1.0, null, null, "Sam Sung OLED SS115", null, 9000000.0, null, 0, null, 1.0 },
                    { "SP0005", null, null, null, null, new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1808), false, null, false, 1.0, 0.0, 1.0, null, null, "Điều hòa Panasonic PA001", null, 6000000.0, null, 0, null, 1.0 },
                    { "SP0006", null, null, null, null, new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1812), false, null, false, 1.0, 0.0, 1.0, null, null, "Máy lạnh Tosiba TSO 7", null, 5000000.0, null, 0, null, 1.0 },
                    { "SP0007", null, null, null, null, new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1813), false, null, false, 1.0, 0.0, 1.0, null, null, "Tủ lạnh LG GG X35", null, 7000000.0, null, 0, null, 1.0 },
                    { "SP0008", null, null, null, null, new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1815), false, null, false, 1.0, 0.0, 1.0, null, null, "Máy giặt AQUA Model 9", null, 8000000.0, null, 0, null, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "Supliers",
                columns: new[] { "Id", "Address", "ContactPerson", "CreatedBy", "CreatedOn", "Discontinued", "Email", "ModifiedBy", "ModifiedOn", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", null, null, "Cty TNHH ABC", "" },
                    { 2, "", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", null, null, "Cty TNHH XYZ", "" },
                    { 3, "", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", null, null, "Cty CP Đông Tây", "" },
                    { 4, "", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", null, null, "Cty CP Nam Bắc", "" },
                    { 5, "", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", null, null, "Tập Đoàn Đa Cấp Xuyên Quốc Gia Cơ Hội", "" },
                    { 6, "", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", null, null, "Nhà Phân Phối Chính Hãng Xiaomi", "" },
                    { 7, "", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "", null, null, "Nhà Phân Phối Chính Hãng Cây Sung", "" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8a971cbf-d7ee-41e3-a77f-d297820f57db", "34daefcc-2e8e-41b1-8ac7-b2675c73fd82" },
                    { "79ddcb7b-18b8-458f-8786-585397bcb2f4", "8a780762-d101-4f56-a211-ffea5ee38ba1" },
                    { "4871a311-e7c2-45ac-81fa-107f0d2a9715", "964da110-c58e-4712-8444-78431873c0f2" },
                    { "cab07f4f-1baa-4317-9149-47af5e8c5b8a", "a55364a8-6367-42b6-b2f1-6d4cfa0adef2" },
                    { "424962f4-963a-45ca-ae2a-b3b59d2043e0", "e6ce47a8-5fcd-49a2-8913-f4b0b6e5c354" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AgencyId",
                table: "AspNetUsers",
                column: "AgencyId",
                unique: true,
                filter: "[AgencyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_ImportId",
                table: "Batches",
                column: "ImportId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_OriginId",
                table: "Batches",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_ProductId",
                table: "Batches",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WarehouseId",
                table: "Employees",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetails_ExportId",
                table: "ExportDetails",
                column: "ExportId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetails_ProductId",
                table: "ExportDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetails_WarehouseId",
                table: "ExportDetails",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exports_AgencyId",
                table: "Exports",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Exports_ManagerId",
                table: "Exports",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetails_ImportId",
                table: "ImportDetails",
                column: "ImportId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetails_ProductId",
                table: "ImportDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Imports_OrderBy",
                table: "Imports",
                column: "OrderBy");

            migrationBuilder.CreateIndex(
                name: "IX_Imports_SuplierId",
                table: "Imports",
                column: "SuplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Imports_WarehouseId",
                table: "Imports",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductId",
                table: "Inventories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_WarehouseId",
                table: "Inventories",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryChecks_AssigneeId",
                table: "InventoryChecks",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryChecks_ManagerId",
                table: "InventoryChecks",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryChecks_ProductId",
                table: "InventoryChecks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryChecks_WarehouseId",
                table: "InventoryChecks",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BatchId",
                table: "Items",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_WarehouseId",
                table: "Items",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Merges_CreatedBy",
                table: "Merges",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Merges_From",
                table: "Merges",
                column: "From");

            migrationBuilder.CreateIndex(
                name: "IX_Merges_ProductId",
                table: "Merges",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Merges_To",
                table: "Merges",
                column: "To");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnDetails_ProductId",
                table: "ReturnDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnDetails_ReturnId",
                table: "ReturnDetails",
                column: "ReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_AgencyId",
                table: "Returns",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_ExportId",
                table: "Returns",
                column: "ExportId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_ManagerId",
                table: "Returns",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_WarehouseId",
                table: "Returns",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_ManagerId",
                table: "Warehouses",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Imports_ImportId",
                table: "Batches",
                column: "ImportId",
                principalTable: "Imports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Warehouses_WarehouseId",
                table: "Employees",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Employees_ManagerId",
                table: "Warehouses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ExportDetails");

            migrationBuilder.DropTable(
                name: "ImportDetails");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "InventoryChecks");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Merges");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "ReturnDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.DropTable(
                name: "Imports");

            migrationBuilder.DropTable(
                name: "Origins");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Exports");

            migrationBuilder.DropTable(
                name: "Supliers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
