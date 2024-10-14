using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedsuplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "85f135da-859f-4096-82bd-e0b69222656b", "0b67b329-40f1-4ba9-a338-d13f389b80ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8255486d-98fd-43b4-ab4f-cec34ee4cb4e", "51025ed6-3680-4dc8-a349-6ebe709a9910" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6412dd30-59a2-44ae-80a7-eb410c61c515", "668ae296-631d-4be0-950b-6a9b7b3f9713" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d15545c5-3bec-4783-888f-5275a8ee131b", "e0c03862-3d1f-4f20-b815-0258c204146a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "540f4e84-661f-4246-ab85-b7d4e68fb65c", "fb955cd6-de38-4438-9ab0-fc125fb6c141" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "540f4e84-661f-4246-ab85-b7d4e68fb65c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6412dd30-59a2-44ae-80a7-eb410c61c515");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8255486d-98fd-43b4-ab4f-cec34ee4cb4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85f135da-859f-4096-82bd-e0b69222656b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d15545c5-3bec-4783-888f-5275a8ee131b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b67b329-40f1-4ba9-a338-d13f389b80ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51025ed6-3680-4dc8-a349-6ebe709a9910");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "668ae296-631d-4be0-950b-6a9b7b3f9713");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0c03862-3d1f-4f20-b815-0258c204146a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb955cd6-de38-4438-9ab0-fc125fb6c141");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a12453d-102f-4cd1-928a-4ec88cebeb93", null, "admin", "ADMIN" },
                    { "6386112a-a338-4566-be73-3d0348980ac5", null, "supermanager", "SUPERMANAGER" },
                    { "72947333-97b1-4e4d-8e8a-7e0c3666c1c7", null, "accountant", "ACCOUNTANT" },
                    { "a10dd2e4-b70f-4b3c-99d8-0e317ca5256a", null, "agency", "AGENCY" },
                    { "bfb2697f-2706-40e8-b7a4-d214b5ab72f8", null, "branchManager", "BRANCHMANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AgencyId", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "EmployeeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "31df6aff-965a-401f-bc6c-f3281423ceba", 0, null, "cacc851c-81bf-45f7-99af-3de7af6fec87", new DateTime(2024, 10, 12, 23, 25, 13, 448, DateTimeKind.Local).AddTicks(1371), "nghuuan2803@gmail.com", false, null, false, null, "NGHUUAN2803@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEIAewrJHbk0wI5BEl60XehvAweNDNQ4VLz4IJ6TjshecJWM4ImfvKnuAt6+ZShV8PQ==", null, false, "e537bef9-ff91-4c5f-8f6a-c447dafe2a09", false, "admin" },
                    { "7e432540-8054-4f22-a474-d4945f4fd154", 0, null, "6557bea6-b2e3-4cea-8ed6-9f06bdb776aa", new DateTime(2024, 10, 12, 23, 25, 13, 448, DateTimeKind.Local).AddTicks(1506), "an2831998@gmail.com", false, null, false, null, "AN2831998@GMAIL.COM", "AGENCY", "AQAAAAIAAYagAAAAEFFw6PhcTqUmZB0dDN2jwjFUekmtHookA1XU6Qr4xtjd9c1dTpLguqUl+2IxFZYMIw==", null, false, "96f3c46c-fa63-4ed6-a61f-f302ed245339", false, "agency" },
                    { "97d7f813-3087-47fa-8c2b-33878aafbc43", 0, null, "1efd6a7e-7789-44ce-8b3e-61ac63283894", new DateTime(2024, 10, 12, 23, 25, 13, 448, DateTimeKind.Local).AddTicks(1514), "abcde@gmail.com", false, null, false, null, "ABCDE@GMAIL.COM", "ACCOUNTANT", "AQAAAAIAAYagAAAAEBmMJqI3C6rm9FkCph6OKkLeU3sDsYj0uUy1XmHzkNVJ5gs/Gy6id8i7SUndIRdiRg==", null, false, "e97cb0c9-71cf-4a5d-9734-3d7f67afaca9", false, "accountant" },
                    { "a1e33903-c511-4c5b-a598-de34dc956add", 0, null, "22f05d88-7fa4-4fa5-947c-1d350d11a8d1", new DateTime(2024, 10, 12, 23, 25, 13, 448, DateTimeKind.Local).AddTicks(1485), "anhuu2803@gmail.com", false, null, false, null, "ANHUU2803@GMAIL.COM", "SUPERMANAGER", "AQAAAAIAAYagAAAAEPmP8PNe8Q8YItzsmWKSC6u1ZxpXg5QGNUTrGzKwOsdG2CPQZJ8Xrcfn8gFYKk84fQ==", null, false, "d3e17136-ce52-43f4-90b9-812733bad665", false, "supermanager" },
                    { "c0bb6a4e-970e-4f89-8aa0-1b3dbed98396", 0, null, "1467f4fb-1bc2-4114-bc88-3ee76e2408d9", new DateTime(2024, 10, 12, 23, 25, 13, 448, DateTimeKind.Local).AddTicks(1495), "huuann28@gmail.com", false, null, false, null, "HUUANN28@GMAIL.COM", "BRANCHMANAGER", "AQAAAAIAAYagAAAAENfMTOoWHPgEdeRFQliHj7CFN2DHc9dk1bA+OCHnGZ7vCWHR5fLebSPS4m1hvsJCZw==", null, false, "14bfecaf-2465-4077-b3a7-b801b188f4b4", false, "branchmanager" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 12, 23, 25, 13, 447, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 12, 23, 25, 13, 447, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 12, 23, 25, 13, 447, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 12, 23, 25, 13, 447, DateTimeKind.Local).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 12, 23, 25, 13, 447, DateTimeKind.Local).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 12, 23, 25, 13, 447, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 12, 23, 25, 13, 447, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 12, 23, 25, 13, 447, DateTimeKind.Local).AddTicks(7911));

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
                    { "0a12453d-102f-4cd1-928a-4ec88cebeb93", "31df6aff-965a-401f-bc6c-f3281423ceba" },
                    { "a10dd2e4-b70f-4b3c-99d8-0e317ca5256a", "7e432540-8054-4f22-a474-d4945f4fd154" },
                    { "72947333-97b1-4e4d-8e8a-7e0c3666c1c7", "97d7f813-3087-47fa-8c2b-33878aafbc43" },
                    { "6386112a-a338-4566-be73-3d0348980ac5", "a1e33903-c511-4c5b-a598-de34dc956add" },
                    { "bfb2697f-2706-40e8-b7a4-d214b5ab72f8", "c0bb6a4e-970e-4f89-8aa0-1b3dbed98396" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0a12453d-102f-4cd1-928a-4ec88cebeb93", "31df6aff-965a-401f-bc6c-f3281423ceba" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a10dd2e4-b70f-4b3c-99d8-0e317ca5256a", "7e432540-8054-4f22-a474-d4945f4fd154" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "72947333-97b1-4e4d-8e8a-7e0c3666c1c7", "97d7f813-3087-47fa-8c2b-33878aafbc43" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6386112a-a338-4566-be73-3d0348980ac5", "a1e33903-c511-4c5b-a598-de34dc956add" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfb2697f-2706-40e8-b7a4-d214b5ab72f8", "c0bb6a4e-970e-4f89-8aa0-1b3dbed98396" });

            migrationBuilder.DeleteData(
                table: "Supliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Supliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Supliers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Supliers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Supliers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Supliers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Supliers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a12453d-102f-4cd1-928a-4ec88cebeb93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6386112a-a338-4566-be73-3d0348980ac5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72947333-97b1-4e4d-8e8a-7e0c3666c1c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a10dd2e4-b70f-4b3c-99d8-0e317ca5256a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfb2697f-2706-40e8-b7a4-d214b5ab72f8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31df6aff-965a-401f-bc6c-f3281423ceba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e432540-8054-4f22-a474-d4945f4fd154");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97d7f813-3087-47fa-8c2b-33878aafbc43");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1e33903-c511-4c5b-a598-de34dc956add");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0bb6a4e-970e-4f89-8aa0-1b3dbed98396");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "540f4e84-661f-4246-ab85-b7d4e68fb65c", null, "supermanager", "SUPERMANAGER" },
                    { "6412dd30-59a2-44ae-80a7-eb410c61c515", null, "agency", "AGENCY" },
                    { "8255486d-98fd-43b4-ab4f-cec34ee4cb4e", null, "admin", "ADMIN" },
                    { "85f135da-859f-4096-82bd-e0b69222656b", null, "branchManager", "BRANCHMANAGER" },
                    { "d15545c5-3bec-4783-888f-5275a8ee131b", null, "accountant", "ACCOUNTANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AgencyId", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "EmployeeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0b67b329-40f1-4ba9-a338-d13f389b80ce", 0, null, "f7a7d434-ea42-4c98-821d-a78ba1cd86a8", new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(5434), "huuann28@gmail.com", false, null, false, null, "HUUANN28@GMAIL.COM", "BRANCHMANAGER", "AQAAAAIAAYagAAAAEOQWZERuXi8rNsrsp6FRGvAP/xoYOLIo2OfFHXert9RC4Wvnh3X81h0yop3IK1YdOQ==", null, false, "b278ef2b-cead-4af1-9e48-7b0529b0298f", false, "branchmanager" },
                    { "51025ed6-3680-4dc8-a349-6ebe709a9910", 0, null, "93c41705-4c47-474c-9594-2bcadf193d6a", new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(5302), "nghuuan2803@gmail.com", false, null, false, null, "NGHUUAN2803@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEL4TqOeyNfxTJh4zdsJ9gFx+KLbWn6pOAawv4mxTvvPQBk80FLgO/AiJJhcOvIMojw==", null, false, "62bdb7c1-e879-4989-b917-93bbdd1133a5", false, "admin" },
                    { "668ae296-631d-4be0-950b-6a9b7b3f9713", 0, null, "b1197b27-b35d-4f04-a712-21f66e4bb191", new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(5443), "an2831998@gmail.com", false, null, false, null, "AN2831998@GMAIL.COM", "AGENCY", "AQAAAAIAAYagAAAAEHq/JqBYqdua48UPteBEpjaPm4IYpshvY1jTMWyIKse49KQbcVuaTS9RdJEWszh4rg==", null, false, "1c49ce23-d10f-406f-a287-bce94f273910", false, "agency" },
                    { "e0c03862-3d1f-4f20-b815-0258c204146a", 0, null, "d626863f-277c-4d91-b5d9-9f4454be5e74", new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(5455), "abcde@gmail.com", false, null, false, null, "ABCDE@GMAIL.COM", "ACCOUNTANT", "AQAAAAIAAYagAAAAEIEGZEEx5a8ThGcR7dtEVXe1hSNnco+y1QC9YNIi+lcaqI4rxI4N7XwIwP9u7fMjCg==", null, false, "a2900c84-6082-4048-8480-f69686893538", false, "accountant" },
                    { "fb955cd6-de38-4438-9ab0-fc125fb6c141", 0, null, "514db0e8-ac8e-42ac-b67b-c213e6802097", new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(5414), "anhuu2803@gmail.com", false, null, false, null, "ANHUU2803@GMAIL.COM", "SUPERMANAGER", "AQAAAAIAAYagAAAAEPdaNqezyLzY0vvSbYxCWW77FbIC+VnLsl4AJxJpIK1OvKKv1X8RauM3torAEus/Pg==", null, false, "98373137-7c8b-4843-993e-e83718a12b03", false, "supermanager" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(1590));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(1605));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(1611));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 23, 14, 14, 194, DateTimeKind.Local).AddTicks(1612));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "85f135da-859f-4096-82bd-e0b69222656b", "0b67b329-40f1-4ba9-a338-d13f389b80ce" },
                    { "8255486d-98fd-43b4-ab4f-cec34ee4cb4e", "51025ed6-3680-4dc8-a349-6ebe709a9910" },
                    { "6412dd30-59a2-44ae-80a7-eb410c61c515", "668ae296-631d-4be0-950b-6a9b7b3f9713" },
                    { "d15545c5-3bec-4783-888f-5275a8ee131b", "e0c03862-3d1f-4f20-b815-0258c204146a" },
                    { "540f4e84-661f-4246-ab85-b7d4e68fb65c", "fb955cd6-de38-4438-9ab0-fc125fb6c141" }
                });
        }
    }
}
