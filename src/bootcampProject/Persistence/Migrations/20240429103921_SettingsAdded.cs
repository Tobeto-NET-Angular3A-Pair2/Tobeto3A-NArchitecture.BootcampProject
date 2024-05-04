using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SettingsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("de2931cc-e6bd-476a-aee2-d4547af2ff17"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("77aa4619-a9db-48c1-a47c-6c674debf0be"));

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleSiteKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleSecretKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleAnalytics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaviconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceMode = table.Column<bool>(type: "bit", nullable: false),
                    TermsOfUse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivacyPolicy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Settings.Admin", null },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Settings.Read", null },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Settings.Write", null },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Settings.Create", null },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Settings.Update", null },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Settings.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Email", "FaviconUrl", "GoogleAnalytics", "GoogleSecretKey", "GoogleSiteKey", "Keywords", "LogoUrl", "MaintenanceMode", "Phone", "PrivacyPolicy", "TermsOfUse", "Title", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2024, 4, 29, 13, 39, 21, 561, DateTimeKind.Local).AddTicks(8114), null, "Description", "Email", "", "", "", "", "Keywords", "", false, "5555 555 55", "", "", "Title", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("e5b256c7-c360-4f33-888a-f0f3ba80c290"), 0, new DateTime(2024, 4, 29, 13, 39, 21, 562, DateTimeKind.Local).AddTicks(3229), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Ays", "Ayd", "", new byte[] { 25, 152, 141, 125, 233, 103, 167, 11, 49, 149, 110, 228, 118, 125, 127, 18, 224, 79, 207, 72, 196, 176, 47, 222, 150, 79, 238, 243, 247, 169, 111, 36, 216, 152, 167, 52, 197, 41, 137, 203, 26, 228, 126, 32, 46, 45, 174, 152, 49, 122, 172, 65, 247, 107, 218, 139, 51, 153, 197, 80, 96, 160, 130, 29 }, new byte[] { 233, 41, 13, 82, 235, 5, 35, 254, 0, 125, 48, 143, 197, 214, 166, 61, 204, 122, 96, 211, 159, 144, 125, 183, 43, 92, 219, 125, 59, 51, 149, 32, 17, 162, 122, 36, 128, 163, 172, 214, 212, 180, 89, 238, 43, 14, 234, 25, 24, 45, 155, 5, 23, 174, 40, 88, 90, 140, 70, 228, 185, 241, 119, 94, 158, 253, 87, 215, 103, 242, 118, 97, 58, 21, 159, 55, 165, 124, 53, 57, 26, 117, 107, 214, 84, 43, 72, 240, 145, 243, 222, 82, 41, 139, 155, 130, 218, 51, 214, 214, 1, 199, 141, 167, 213, 99, 206, 99, 171, 193, 91, 32, 174, 208, 153, 156, 6, 232, 26, 95, 24, 175, 201, 167, 189, 91, 196, 9 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e136072c-aad2-46dc-9b8c-63c4554bccc1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("e5b256c7-c360-4f33-888a-f0f3ba80c290") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e136072c-aad2-46dc-9b8c-63c4554bccc1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e5b256c7-c360-4f33-888a-f0f3ba80c290"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("77aa4619-a9db-48c1-a47c-6c674debf0be"), 0, new DateTime(2024, 3, 26, 18, 35, 39, 441, DateTimeKind.Local).AddTicks(8592), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Ays", "Ayd", "", new byte[] { 227, 133, 53, 215, 227, 42, 48, 208, 183, 159, 66, 119, 57, 203, 167, 0, 61, 131, 62, 110, 139, 49, 26, 106, 65, 100, 95, 168, 35, 226, 244, 149, 233, 213, 99, 2, 32, 236, 177, 187, 225, 88, 66, 206, 193, 184, 240, 120, 232, 44, 45, 50, 234, 177, 178, 191, 38, 80, 156, 251, 241, 169, 200, 225 }, new byte[] { 235, 56, 160, 129, 133, 114, 225, 136, 128, 156, 32, 188, 207, 223, 85, 84, 137, 42, 88, 37, 68, 255, 144, 220, 248, 201, 16, 90, 194, 224, 96, 206, 6, 249, 149, 43, 72, 204, 6, 148, 190, 151, 23, 240, 22, 105, 218, 91, 74, 63, 83, 28, 101, 173, 239, 229, 211, 233, 55, 184, 52, 111, 184, 145, 38, 238, 234, 59, 178, 128, 195, 174, 148, 89, 150, 16, 12, 203, 248, 224, 199, 86, 247, 56, 237, 173, 33, 41, 169, 69, 104, 93, 44, 148, 21, 24, 127, 146, 223, 217, 186, 98, 249, 144, 79, 80, 57, 61, 135, 191, 42, 11, 185, 77, 90, 1, 190, 117, 155, 98, 127, 113, 42, 219, 90, 238, 214, 5 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("de2931cc-e6bd-476a-aee2-d4547af2ff17"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("77aa4619-a9db-48c1-a47c-6c674debf0be") });
        }
    }
}
