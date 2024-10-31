using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addsignaturehtml : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a8064474-4e75-4548-8ac4-58822541d13c", "5d8bffe9-724b-4f19-8a09-c07103d894b1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5abcf1e8-eb3e-43a7-a53c-2c6e2406e2aa", "5e3815fb-a30e-489a-bd3c-d7ec199871b5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "17966237-a5af-4ce5-b23a-91f9974738fb", "a8c0215a-a5e9-48f3-9e59-4298d890ce8c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d9d3385e-fcc1-46fc-a619-d40e58a577c0", "d748179c-cd9e-4e84-854c-1774f4ab2309" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9ecc4e09-a92f-464a-8653-5e6be8280091", "f66a36cf-cc0f-4075-b0ec-ef68c0c6a8f4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17966237-a5af-4ce5-b23a-91f9974738fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5abcf1e8-eb3e-43a7-a53c-2c6e2406e2aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ecc4e09-a92f-464a-8653-5e6be8280091");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8064474-4e75-4548-8ac4-58822541d13c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9d3385e-fcc1-46fc-a619-d40e58a577c0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d8bffe9-724b-4f19-8a09-c07103d894b1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e3815fb-a30e-489a-bd3c-d7ec199871b5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8c0215a-a5e9-48f3-9e59-4298d890ce8c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d748179c-cd9e-4e84-854c-1774f4ab2309");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66a36cf-cc0f-4075-b0ec-ef68c0c6a8f4");

            migrationBuilder.CreateTable(
                name: "HtmlSignatures",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlSignatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportReports",
                columns: table => new
                {
                    Month = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportReports", x => x.Month);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "470f6ae5-398e-41d0-ad73-368d6bb8d531", null, "keeper", "KEEPER" },
                    { "77f15332-4dae-4ed4-823c-3c45d0f863e0", null, "accountant", "ACCOUNTANT" },
                    { "7a118750-249e-416f-bf62-c6414891bdd4", null, "agency", "AGENCY" },
                    { "9da09547-4427-42de-b075-93e5514ed77b", null, "admin", "ADMIN" },
                    { "f0708d52-9e0d-4dd0-97de-93c96435b928", null, "manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AgencyId", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "EmployeeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rfid", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1e276d5f-5201-48e4-8b66-bae0c6c8f312", 0, null, "36b4c105-81ef-4550-bf78-b84197b57eec", new DateTime(2024, 10, 30, 22, 17, 33, 114, DateTimeKind.Local).AddTicks(2250), "admin@gmail.com", false, null, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEI97xhr2ro/6bE+LJnoekUfmWXXY0MdvhjDe+Zmwrd9aHmQuVOStDh6CA2F3GsSQxw==", null, false, null, "1f6185c4-ca80-4c33-8c35-8320fbb7a57e", false, "admin" },
                    { "8374e933-e66f-400d-9950-dbc08846e2de", 0, null, "c0c36e0f-47e4-4743-a1e3-e6095a15ddeb", new DateTime(2024, 10, 30, 22, 17, 33, 114, DateTimeKind.Local).AddTicks(2382), "manager@gmail.com", false, null, false, null, "MANAGER@GMAIL.COM", "MANAGER", "AQAAAAIAAYagAAAAECDDwg1+GFw+Jrtg6UdAevlQVJtP0btNixxZvkPr0vMIvyIC4n4DHzvW4WCJ8uzKHg==", null, false, null, "680ac0e7-f3a7-404c-9179-07a4d580a931", false, "manager" },
                    { "9645147c-dec7-42ed-891c-a61abee4c9d8", 0, null, "10aa0fda-bd63-45f5-be7a-94a260c39e98", new DateTime(2024, 10, 30, 22, 17, 33, 114, DateTimeKind.Local).AddTicks(2404), "agency1@gmail.com", false, null, false, null, "AGENCY1@GMAIL.COM", "AGENCY1", "AQAAAAIAAYagAAAAEPkEroCmM38BerXxC8zZMi1M8Tyzm6LjQQsibicaoqVAfth3Hd51Wih8wvoVV0b/gA==", null, false, null, "15d50a7e-088d-4af1-868a-0d80b660b506", false, "agency1" },
                    { "b57ce7ea-b386-4adb-8302-deeaa8125c89", 0, null, "f10ebd05-a94b-4844-b97c-f5b2ba353769", new DateTime(2024, 10, 30, 22, 17, 33, 114, DateTimeKind.Local).AddTicks(2412), "accountant@gmail.com", false, null, false, null, "ACCOUNTANT@GMAIL.COM", "ACCOUNTANT", "AQAAAAIAAYagAAAAECCdEshDVnoQ+h5mn1Eg5rmOe6vbaKvKNYsLYFcA+q6gx0nl//B80B+e8kt8E5xZjQ==", null, false, null, "5dd56349-b88d-4570-9c60-e97ababc609d", false, "accountant" },
                    { "ee8bb32b-e0e8-45f4-bd76-4c19be35dc60", 0, null, "0f989c4c-3f22-4ee6-8765-6e0cb97705b9", new DateTime(2024, 10, 30, 22, 17, 33, 114, DateTimeKind.Local).AddTicks(2392), "keeper@gmail.com", false, null, false, null, "KEEPER@GMAIL.COM", "KEEPER", "AQAAAAIAAYagAAAAEFeFI6d3Gsqcs5w4dM7sKd1hRDAAxOc7lt9dI0/uUixVo5JZ3GmRAclfwr9eizaKzQ==", null, false, null, "d299e4c0-e526-44dd-9cae-00a726cf6d7a", false, "keeper" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0001",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 22, 17, 33, 113, DateTimeKind.Local).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0002",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 22, 17, 33, 113, DateTimeKind.Local).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0003",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 22, 17, 33, 113, DateTimeKind.Local).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0004",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 22, 17, 33, 113, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0005",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 22, 17, 33, 113, DateTimeKind.Local).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0006",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 22, 17, 33, 113, DateTimeKind.Local).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0007",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 22, 17, 33, 113, DateTimeKind.Local).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0008",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 22, 17, 33, 113, DateTimeKind.Local).AddTicks(8775));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9da09547-4427-42de-b075-93e5514ed77b", "1e276d5f-5201-48e4-8b66-bae0c6c8f312" },
                    { "f0708d52-9e0d-4dd0-97de-93c96435b928", "8374e933-e66f-400d-9950-dbc08846e2de" },
                    { "7a118750-249e-416f-bf62-c6414891bdd4", "9645147c-dec7-42ed-891c-a61abee4c9d8" },
                    { "77f15332-4dae-4ed4-823c-3c45d0f863e0", "b57ce7ea-b386-4adb-8302-deeaa8125c89" },
                    { "470f6ae5-398e-41d0-ad73-368d6bb8d531", "ee8bb32b-e0e8-45f4-bd76-4c19be35dc60" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HtmlSignatures");

            migrationBuilder.DropTable(
                name: "ImportReports");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9da09547-4427-42de-b075-93e5514ed77b", "1e276d5f-5201-48e4-8b66-bae0c6c8f312" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f0708d52-9e0d-4dd0-97de-93c96435b928", "8374e933-e66f-400d-9950-dbc08846e2de" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7a118750-249e-416f-bf62-c6414891bdd4", "9645147c-dec7-42ed-891c-a61abee4c9d8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "77f15332-4dae-4ed4-823c-3c45d0f863e0", "b57ce7ea-b386-4adb-8302-deeaa8125c89" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "470f6ae5-398e-41d0-ad73-368d6bb8d531", "ee8bb32b-e0e8-45f4-bd76-4c19be35dc60" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "470f6ae5-398e-41d0-ad73-368d6bb8d531");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77f15332-4dae-4ed4-823c-3c45d0f863e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a118750-249e-416f-bf62-c6414891bdd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9da09547-4427-42de-b075-93e5514ed77b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0708d52-9e0d-4dd0-97de-93c96435b928");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e276d5f-5201-48e4-8b66-bae0c6c8f312");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8374e933-e66f-400d-9950-dbc08846e2de");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9645147c-dec7-42ed-891c-a61abee4c9d8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b57ce7ea-b386-4adb-8302-deeaa8125c89");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee8bb32b-e0e8-45f4-bd76-4c19be35dc60");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17966237-a5af-4ce5-b23a-91f9974738fb", null, "admin", "ADMIN" },
                    { "5abcf1e8-eb3e-43a7-a53c-2c6e2406e2aa", null, "agency", "AGENCY" },
                    { "9ecc4e09-a92f-464a-8653-5e6be8280091", null, "keeper", "KEEPER" },
                    { "a8064474-4e75-4548-8ac4-58822541d13c", null, "accountant", "ACCOUNTANT" },
                    { "d9d3385e-fcc1-46fc-a619-d40e58a577c0", null, "manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AgencyId", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "EmployeeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rfid", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5d8bffe9-724b-4f19-8a09-c07103d894b1", 0, null, "acde2e30-82f5-4ae8-b614-5d591abe3a1a", new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(8030), "accountant@gmail.com", false, null, false, null, "ACCOUNTANT@GMAIL.COM", "ACCOUNTANT", "AQAAAAIAAYagAAAAEAcpVXTiCNjdtt2CROC9UZ70qde7GeBg9tYeu4CJwTWuGHYmwkXM6t2/b+kNnyc4Wg==", null, false, null, "965896f6-44c6-49f0-8ea5-0addf68d242b", false, "accountant" },
                    { "5e3815fb-a30e-489a-bd3c-d7ec199871b5", 0, null, "14d50d85-ada8-47eb-95a5-c2d29b6e2441", new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(8019), "agency1@gmail.com", false, null, false, null, "AGENCY1@GMAIL.COM", "AGENCY1", "AQAAAAIAAYagAAAAEOQSZS3r8Ix19XlIeZenNsoJITmWZRhZos1U1APbK7jHLMKOEMDeNTSjkXWSB/BPaQ==", null, false, null, "29eeb37a-73ab-4e15-a8be-fd666250eaa9", false, "agency1" },
                    { "a8c0215a-a5e9-48f3-9e59-4298d890ce8c", 0, null, "02da56ac-d2c2-4319-ab9f-2a6bedcc51f6", new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(7873), "admin@gmail.com", false, null, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEOeYmF2SkH8paFy3X4TxCmkvfsUdKCRZsqY2ZTIcfsC27X5oUlJU0HNVUfdW7cu11w==", null, false, null, "cb3b2d51-1dae-43fd-9374-8ba23be1192a", false, "admin" },
                    { "d748179c-cd9e-4e84-854c-1774f4ab2309", 0, null, "f6446f68-dfe2-4322-9f43-7efc0001af41", new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(7983), "manager@gmail.com", false, null, false, null, "MANAGER@GMAIL.COM", "MANAGER", "AQAAAAIAAYagAAAAEI9x5156oW3aRdtQVnrUgnP51QdAVX8Hxb6R8zWZo2SLqBT7UM7LwdEJxoiH5o7z7A==", null, false, null, "64ad570d-5cca-4f48-89ef-cf438c4203e4", false, "manager" },
                    { "f66a36cf-cc0f-4075-b0ec-ef68c0c6a8f4", 0, null, "1572ff0a-2e76-46b4-bee7-1d4247bb08d6", new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(8010), "keeper@gmail.com", false, null, false, null, "KEEPER@GMAIL.COM", "KEEPER", "AQAAAAIAAYagAAAAECm69Id780RnqSyxwVfjijJ4vFbbyvR9Ho+mhhMCpjwWsmIgdLJqLsqa9yYRnwlL1g==", null, false, null, "fe5ce251-2e5d-4dd6-925b-b8de02266e09", false, "keeper" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0001",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0002",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0003",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0004",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(5704));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0005",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(5706));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0006",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(5709));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0007",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(5711));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0008",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 30, 0, 0, 33, 604, DateTimeKind.Local).AddTicks(5713));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a8064474-4e75-4548-8ac4-58822541d13c", "5d8bffe9-724b-4f19-8a09-c07103d894b1" },
                    { "5abcf1e8-eb3e-43a7-a53c-2c6e2406e2aa", "5e3815fb-a30e-489a-bd3c-d7ec199871b5" },
                    { "17966237-a5af-4ce5-b23a-91f9974738fb", "a8c0215a-a5e9-48f3-9e59-4298d890ce8c" },
                    { "d9d3385e-fcc1-46fc-a619-d40e58a577c0", "d748179c-cd9e-4e84-854c-1774f4ab2309" },
                    { "9ecc4e09-a92f-464a-8653-5e6be8280091", "f66a36cf-cc0f-4075-b0ec-ef68c0c6a8f4" }
                });
        }
    }
}
