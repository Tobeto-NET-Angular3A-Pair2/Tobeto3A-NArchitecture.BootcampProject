using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class contact : Migration
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
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Contacts.Admin", null },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Contacts.Read", null },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Contacts.Write", null },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Contacts.Create", null },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Contacts.Update", null },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Contacts.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("3d29795c-1568-4f6f-ac57-673060301915"), 0, new DateTime(2024, 4, 29, 22, 54, 45, 959, DateTimeKind.Local).AddTicks(3341), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Ays", "Ayd", "", new byte[] { 48, 4, 134, 35, 18, 219, 207, 72, 138, 41, 31, 57, 61, 74, 14, 157, 70, 182, 237, 212, 12, 99, 212, 36, 71, 18, 222, 45, 205, 147, 170, 0, 188, 164, 136, 99, 18, 224, 46, 209, 172, 239, 237, 142, 32, 150, 97, 68, 27, 18, 160, 153, 69, 198, 0, 13, 27, 30, 138, 117, 125, 25, 178, 69 }, new byte[] { 172, 177, 56, 102, 33, 53, 248, 252, 203, 162, 215, 141, 205, 83, 251, 219, 88, 47, 132, 199, 105, 173, 237, 112, 123, 166, 20, 253, 170, 178, 243, 179, 19, 35, 157, 106, 124, 161, 226, 53, 255, 180, 213, 176, 29, 170, 129, 179, 243, 30, 227, 174, 217, 58, 132, 167, 90, 83, 99, 176, 107, 212, 150, 158, 24, 182, 144, 72, 249, 155, 151, 240, 167, 227, 57, 218, 65, 186, 150, 186, 212, 8, 143, 67, 121, 216, 11, 164, 218, 18, 55, 80, 132, 254, 250, 12, 183, 248, 55, 239, 123, 230, 114, 169, 138, 143, 201, 45, 23, 154, 19, 132, 134, 210, 110, 239, 0, 115, 77, 103, 188, 215, 136, 49, 236, 116, 39, 11 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("bb86ad7f-3e2a-4796-bd89-0dae08512952"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3d29795c-1568-4f6f-ac57-673060301915") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

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
                keyValue: new Guid("bb86ad7f-3e2a-4796-bd89-0dae08512952"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d29795c-1568-4f6f-ac57-673060301915"));

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
