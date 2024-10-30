using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addnotify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8a971cbf-d7ee-41e3-a77f-d297820f57db", "34daefcc-2e8e-41b1-8ac7-b2675c73fd82" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "79ddcb7b-18b8-458f-8786-585397bcb2f4", "8a780762-d101-4f56-a211-ffea5ee38ba1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4871a311-e7c2-45ac-81fa-107f0d2a9715", "964da110-c58e-4712-8444-78431873c0f2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cab07f4f-1baa-4317-9149-47af5e8c5b8a", "a55364a8-6367-42b6-b2f1-6d4cfa0adef2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "424962f4-963a-45ca-ae2a-b3b59d2043e0", "e6ce47a8-5fcd-49a2-8913-f4b0b6e5c354" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "424962f4-963a-45ca-ae2a-b3b59d2043e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4871a311-e7c2-45ac-81fa-107f0d2a9715");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79ddcb7b-18b8-458f-8786-585397bcb2f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a971cbf-d7ee-41e3-a77f-d297820f57db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cab07f4f-1baa-4317-9149-47af5e8c5b8a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34daefcc-2e8e-41b1-8ac7-b2675c73fd82");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a780762-d101-4f56-a211-ffea5ee38ba1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "964da110-c58e-4712-8444-78431873c0f2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a55364a8-6367-42b6-b2f1-6d4cfa0adef2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6ce47a8-5fcd-49a2-8913-f4b0b6e5c354");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverId = table.Column<string>(type: "varchar(10)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Employees_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications",
                column: "ReceiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0001",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0002",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0003",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0004",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0005",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0006",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0007",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "SP0008",
                column: "CreatedOn",
                value: new DateTime(2024, 10, 29, 18, 23, 56, 208, DateTimeKind.Local).AddTicks(1815));

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
        }
    }
}
