using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeddatacount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 22, 21, 43, 281, DateTimeKind.Local).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 22, 21, 43, 281, DateTimeKind.Local).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 22, 21, 43, 281, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 22, 21, 43, 281, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 22, 21, 43, 281, DateTimeKind.Local).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 22, 21, 43, 281, DateTimeKind.Local).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 22, 21, 43, 281, DateTimeKind.Local).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 2, 22, 21, 43, 281, DateTimeKind.Local).AddTicks(4982));
        }
    }
}
