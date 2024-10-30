using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatenotify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "45952bef-7da0-48c1-a10d-9163243302d3", "206cc04b-6738-4170-ace3-1cb76230896d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad4e9e93-338f-48cf-aa5a-3ce03b394c78", "7300478c-37df-46c2-b248-e9bd6b5ca0f2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bc47bdef-beab-44d7-a63d-0ea434da7932", "89cb643d-6a09-46bb-bf0e-4e80f3ab640a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a8d964dd-6732-44b8-8425-f6b2e83b02cc", "ba3fff5b-9fff-432c-97fc-ef704bfecf4f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "423aa5d0-bf5f-41ae-856b-1e60c84ceeaa", "e43dc0ea-45f6-4a7d-8d03-1b2bdd6dcbad" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "423aa5d0-bf5f-41ae-856b-1e60c84ceeaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45952bef-7da0-48c1-a10d-9163243302d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8d964dd-6732-44b8-8425-f6b2e83b02cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad4e9e93-338f-48cf-aa5a-3ce03b394c78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc47bdef-beab-44d7-a63d-0ea434da7932");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "206cc04b-6738-4170-ace3-1cb76230896d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7300478c-37df-46c2-b248-e9bd6b5ca0f2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89cb643d-6a09-46bb-bf0e-4e80f3ab640a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba3fff5b-9fff-432c-97fc-ef704bfecf4f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43dc0ea-45f6-4a7d-8d03-1b2bdd6dcbad");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Notifications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "423aa5d0-bf5f-41ae-856b-1e60c84ceeaa", null, "keeper", "KEEPER" },
                    { "45952bef-7da0-48c1-a10d-9163243302d3", null, "agency", "AGENCY" },
                    { "a8d964dd-6732-44b8-8425-f6b2e83b02cc", null, "manager", "MANAGER" },
                    { "ad4e9e93-338f-48cf-aa5a-3ce03b394c78", null, "accountant", "ACCOUNTANT" },
                    { "bc47bdef-beab-44d7-a63d-0ea434da7932", null, "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AgencyId", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "EmployeeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rfid", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "206cc04b-6738-4170-ace3-1cb76230896d", 0, null, "6edca16b-2f29-4ec2-87eb-108ebd328b62", new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(2896), "agency1@gmail.com", false, null, false, null, "AGENCY1@GMAIL.COM", "AGENCY1", "AQAAAAIAAYagAAAAEAtA9Sb5YcsxTLBMvfArn7sO1WMI3cc4o6zJIzywZHLE3VnMIjkl8E36X+Ukm3R/Nw==", null, false, null, "e8f66af3-2f2a-43ef-b23a-307202f7617b", false, "agency1" },
                    { "7300478c-37df-46c2-b248-e9bd6b5ca0f2", 0, null, "cd8d2e0e-2ba9-4acd-a398-08f7fe6fabb8", new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(2915), "accountant@gmail.com", false, null, false, null, "ACCOUNTANT@GMAIL.COM", "ACCOUNTANT", "AQAAAAIAAYagAAAAEAZS1C07J6i6ZRxGTkUII5wxHAZwrG/iCb3JwcutQrPujQz5Ixsp3mRSIE7mS559EQ==", null, false, null, "2833ab71-b51e-4431-866f-59d03d931468", false, "accountant" },
                    { "89cb643d-6a09-46bb-bf0e-4e80f3ab640a", 0, null, "78b67919-efec-4898-857d-f625b2a86700", new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(2748), "admin@gmail.com", false, null, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEI98qJHx8K4k3WTC+J1hjdI2bORVAL/7gQPgXnB6pNNCwuwFWBHAJ+JmN1uewcb4CQ==", null, false, null, "9cbc6b5a-6a2b-4af6-9558-0770f8bc18f9", false, "admin" },
                    { "ba3fff5b-9fff-432c-97fc-ef704bfecf4f", 0, null, "c70b0b17-ce18-4c4c-a0eb-94cf3b69f2fd", new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(2866), "manager@gmail.com", false, null, false, null, "MANAGER@GMAIL.COM", "MANAGER", "AQAAAAIAAYagAAAAEF4pFOvXdeUqSBTCPApf4kdyoQgTreJm2H4jzVJHHbzPmdd5Q0eB2ieFEhFhEFUtwA==", null, false, null, "404a3934-98c2-4eeb-9db5-f4555c99a298", false, "manager" },
                    { "e43dc0ea-45f6-4a7d-8d03-1b2bdd6dcbad", 0, null, "079f62b9-f82b-4b21-8572-8cfed0a7d1ea", new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(2888), "keeper@gmail.com", false, null, false, null, "KEEPER@GMAIL.COM", "KEEPER", "AQAAAAIAAYagAAAAEL3fybv/+Bb5+JbQjZzoxpgtTwRKwhZTYpTgOWM3cFpn+RiubAfZyAbtU7esvCqBIw==", null, false, null, "ef3e47c9-3ee7-43b4-9554-09d0b6c1f3c6", false, "keeper" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0001",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0002",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(624));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0003",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(626));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0004",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0005",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(630));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0006",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0007",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(636));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0008",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 23, 45, 19, 427, DateTimeKind.Local).AddTicks(638));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "45952bef-7da0-48c1-a10d-9163243302d3", "206cc04b-6738-4170-ace3-1cb76230896d" },
                    { "ad4e9e93-338f-48cf-aa5a-3ce03b394c78", "7300478c-37df-46c2-b248-e9bd6b5ca0f2" },
                    { "bc47bdef-beab-44d7-a63d-0ea434da7932", "89cb643d-6a09-46bb-bf0e-4e80f3ab640a" },
                    { "a8d964dd-6732-44b8-8425-f6b2e83b02cc", "ba3fff5b-9fff-432c-97fc-ef704bfecf4f" },
                    { "423aa5d0-bf5f-41ae-856b-1e60c84ceeaa", "e43dc0ea-45f6-4a7d-8d03-1b2bdd6dcbad" }
                });
        }
    }
}
