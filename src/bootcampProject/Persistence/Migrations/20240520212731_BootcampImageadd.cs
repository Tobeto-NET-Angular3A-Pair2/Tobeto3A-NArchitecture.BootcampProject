using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BootcampImageadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1612e2c0-27d2-4927-b898-51dec066aaa1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a9420a40-c9df-4d32-8f89-4ea3f9e91ea6"));

            migrationBuilder.AddColumn<string>(
                name: "BootcampImage",
                table: "Bootcamps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 0, 27, 30, 566, DateTimeKind.Local).AddTicks(6697));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("3ef1ba55-5e17-48bc-873e-cc860404bb54"), 0, new DateTime(2024, 5, 21, 0, 27, 30, 567, DateTimeKind.Local).AddTicks(4170), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Ays", "Ayd", "", new byte[] { 70, 112, 229, 86, 112, 18, 55, 45, 91, 220, 43, 41, 55, 235, 101, 101, 211, 241, 162, 121, 114, 101, 172, 83, 96, 12, 22, 25, 112, 245, 248, 147, 213, 52, 142, 105, 36, 172, 174, 233, 45, 146, 85, 128, 200, 4, 39, 159, 95, 147, 29, 232, 94, 254, 158, 174, 166, 244, 163, 96, 230, 232, 41, 99 }, new byte[] { 218, 252, 238, 23, 145, 157, 234, 5, 129, 65, 103, 17, 135, 155, 78, 251, 134, 76, 27, 14, 58, 136, 253, 240, 251, 164, 9, 249, 190, 127, 62, 47, 96, 124, 149, 115, 134, 211, 245, 153, 19, 227, 69, 126, 254, 143, 195, 36, 181, 95, 133, 78, 125, 34, 179, 2, 184, 144, 201, 189, 137, 192, 80, 60, 31, 65, 243, 141, 155, 12, 3, 5, 93, 112, 73, 105, 165, 194, 140, 53, 9, 209, 121, 254, 216, 73, 146, 196, 204, 180, 53, 28, 40, 168, 111, 143, 247, 242, 207, 195, 158, 226, 119, 117, 94, 79, 49, 167, 60, 66, 200, 194, 68, 178, 163, 88, 86, 35, 145, 236, 155, 27, 33, 149, 65, 58, 245, 215 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("bdaaeafe-9381-4cbd-978d-4ebd1d48b9a4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3ef1ba55-5e17-48bc-873e-cc860404bb54") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("bdaaeafe-9381-4cbd-978d-4ebd1d48b9a4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3ef1ba55-5e17-48bc-873e-cc860404bb54"));

            migrationBuilder.DropColumn(
                name: "BootcampImage",
                table: "Bootcamps");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 19, 6, 53, 2, 71, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("a9420a40-c9df-4d32-8f89-4ea3f9e91ea6"), 0, new DateTime(2024, 5, 19, 6, 53, 2, 72, DateTimeKind.Local).AddTicks(3332), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Ays", "Ayd", "", new byte[] { 91, 70, 242, 223, 247, 147, 77, 190, 0, 206, 68, 76, 4, 235, 243, 239, 188, 211, 87, 206, 137, 251, 104, 115, 201, 242, 242, 142, 87, 227, 177, 145, 210, 247, 88, 121, 74, 241, 60, 228, 105, 176, 215, 55, 36, 120, 172, 139, 75, 74, 59, 252, 28, 232, 189, 165, 168, 62, 6, 49, 42, 206, 53, 106 }, new byte[] { 250, 177, 140, 37, 89, 174, 60, 148, 39, 48, 74, 150, 52, 27, 96, 83, 23, 181, 15, 250, 196, 134, 236, 50, 65, 58, 135, 137, 185, 157, 240, 96, 32, 188, 164, 59, 91, 46, 5, 225, 124, 3, 40, 84, 147, 182, 101, 111, 25, 174, 244, 56, 112, 250, 104, 23, 164, 56, 211, 97, 200, 78, 125, 23, 27, 244, 233, 109, 66, 181, 9, 207, 77, 109, 238, 246, 38, 20, 155, 75, 49, 82, 150, 148, 73, 55, 130, 38, 124, 189, 252, 62, 120, 100, 48, 224, 0, 176, 93, 29, 195, 150, 60, 169, 23, 239, 209, 76, 70, 167, 161, 57, 116, 92, 139, 50, 70, 248, 198, 133, 96, 107, 75, 68, 117, 144, 46, 222 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1612e2c0-27d2-4927-b898-51dec066aaa1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a9420a40-c9df-4d32-8f89-4ea3f9e91ea6") });
        }
    }
}
