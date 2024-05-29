using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddInstructorApplication : Migration
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
                name: "InstructorApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorApplications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "InstructorApplications.Admin", null },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "InstructorApplications.Read", null },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "InstructorApplications.Write", null },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "InstructorApplications.Create", null },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "InstructorApplications.Update", null },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "InstructorApplications.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("2b2f9850-45d7-4f60-be3e-2ed90232d0e6"), 0, new DateTime(2024, 4, 30, 20, 47, 24, 839, DateTimeKind.Local).AddTicks(7222), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Ays", "Ayd", "", new byte[] { 23, 123, 167, 133, 193, 116, 177, 247, 251, 146, 194, 176, 97, 96, 94, 92, 16, 234, 148, 42, 91, 163, 202, 241, 10, 175, 245, 155, 19, 40, 66, 164, 249, 113, 73, 20, 182, 29, 129, 223, 228, 225, 34, 74, 182, 210, 66, 45, 158, 188, 228, 58, 15, 87, 60, 224, 134, 96, 109, 143, 22, 13, 93, 18 }, new byte[] { 165, 101, 87, 46, 253, 244, 32, 85, 87, 134, 208, 113, 34, 140, 115, 136, 255, 31, 122, 164, 7, 135, 174, 154, 98, 43, 61, 70, 119, 236, 180, 88, 155, 31, 114, 47, 243, 128, 13, 82, 166, 159, 136, 92, 173, 5, 94, 252, 138, 183, 166, 244, 128, 150, 30, 149, 237, 135, 117, 227, 126, 39, 95, 161, 213, 38, 61, 128, 139, 221, 252, 140, 217, 78, 131, 23, 203, 24, 68, 130, 172, 10, 206, 117, 20, 201, 144, 148, 15, 213, 33, 201, 64, 178, 60, 215, 91, 55, 81, 67, 214, 95, 239, 74, 2, 226, 224, 22, 133, 192, 210, 46, 230, 235, 142, 122, 94, 72, 249, 95, 224, 223, 74, 46, 163, 214, 63, 189 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8398a7a5-4864-4959-a533-3a9ba4de000a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("2b2f9850-45d7-4f60-be3e-2ed90232d0e6") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorApplications");

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
                keyValue: new Guid("8398a7a5-4864-4959-a533-3a9ba4de000a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b2f9850-45d7-4f60-be3e-2ed90232d0e6"));

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
