using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class contact2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { new Guid("b3529d77-978b-4d77-8906-4a5e30b173c4"), 0, new DateTime(2024, 4, 30, 19, 10, 26, 851, DateTimeKind.Local).AddTicks(2768), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Ays", "Ayd", "", new byte[] { 212, 59, 200, 2, 53, 74, 225, 12, 248, 183, 101, 85, 105, 254, 114, 187, 175, 207, 57, 31, 175, 101, 139, 177, 134, 210, 164, 24, 110, 154, 223, 215, 196, 248, 135, 11, 88, 220, 162, 29, 124, 110, 28, 209, 96, 99, 238, 208, 242, 39, 37, 3, 59, 206, 246, 227, 87, 168, 255, 34, 146, 246, 223, 129 }, new byte[] { 210, 222, 210, 41, 183, 224, 28, 232, 191, 114, 225, 247, 8, 132, 250, 73, 91, 150, 70, 80, 127, 250, 222, 2, 173, 193, 70, 207, 102, 144, 130, 249, 225, 91, 204, 73, 179, 190, 60, 224, 144, 144, 49, 103, 214, 138, 16, 112, 234, 95, 172, 225, 185, 186, 24, 244, 139, 196, 41, 92, 35, 137, 255, 69, 215, 75, 62, 79, 202, 146, 129, 51, 227, 39, 65, 13, 134, 32, 244, 139, 237, 133, 15, 221, 238, 78, 133, 240, 97, 48, 197, 180, 220, 26, 159, 50, 133, 3, 93, 191, 100, 206, 208, 4, 125, 93, 74, 176, 152, 179, 225, 13, 240, 213, 29, 125, 75, 86, 81, 15, 250, 119, 0, 211, 250, 53, 253, 29 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("02968bac-25ce-4153-ab74-97537a577349"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b3529d77-978b-4d77-8906-4a5e30b173c4") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("02968bac-25ce-4153-ab74-97537a577349"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b3529d77-978b-4d77-8906-4a5e30b173c4"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("3d29795c-1568-4f6f-ac57-673060301915"), 0, new DateTime(2024, 4, 29, 22, 54, 45, 959, DateTimeKind.Local).AddTicks(3341), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Ays", "Ayd", "", new byte[] { 48, 4, 134, 35, 18, 219, 207, 72, 138, 41, 31, 57, 61, 74, 14, 157, 70, 182, 237, 212, 12, 99, 212, 36, 71, 18, 222, 45, 205, 147, 170, 0, 188, 164, 136, 99, 18, 224, 46, 209, 172, 239, 237, 142, 32, 150, 97, 68, 27, 18, 160, 153, 69, 198, 0, 13, 27, 30, 138, 117, 125, 25, 178, 69 }, new byte[] { 172, 177, 56, 102, 33, 53, 248, 252, 203, 162, 215, 141, 205, 83, 251, 219, 88, 47, 132, 199, 105, 173, 237, 112, 123, 166, 20, 253, 170, 178, 243, 179, 19, 35, 157, 106, 124, 161, 226, 53, 255, 180, 213, 176, 29, 170, 129, 179, 243, 30, 227, 174, 217, 58, 132, 167, 90, 83, 99, 176, 107, 212, 150, 158, 24, 182, 144, 72, 249, 155, 151, 240, 167, 227, 57, 218, 65, 186, 150, 186, 212, 8, 143, 67, 121, 216, 11, 164, 218, 18, 55, 80, 132, 254, 250, 12, 183, 248, 55, 239, 123, 230, 114, 169, 138, 143, 201, 45, 23, 154, 19, 132, 134, 210, 110, 239, 0, 115, 77, 103, 188, 215, 136, 49, 236, 116, 39, 11 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("bb86ad7f-3e2a-4796-bd89-0dae08512952"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3d29795c-1568-4f6f-ac57-673060301915") });
        }
    }
}
