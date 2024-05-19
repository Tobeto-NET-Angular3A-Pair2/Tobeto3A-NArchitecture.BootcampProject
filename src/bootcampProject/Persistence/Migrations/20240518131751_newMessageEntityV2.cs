using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newMessageEntityV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("85142f4b-045a-43a0-8b9a-5a141def5c47"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fab2e156-8c52-46b3-b5fd-5f1bb980128d"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("685c3a51-e2ce-4458-b6d0-af11d1ebbc92"), 0, new DateTime(2024, 5, 18, 16, 17, 48, 537, DateTimeKind.Local).AddTicks(6267), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Ays", "Ayd", "", new byte[] { 119, 242, 142, 251, 58, 142, 74, 162, 134, 218, 163, 249, 39, 123, 188, 82, 5, 121, 84, 130, 19, 104, 88, 92, 193, 177, 3, 197, 232, 53, 210, 208, 246, 65, 184, 186, 50, 192, 248, 214, 14, 166, 114, 176, 241, 181, 226, 25, 251, 16, 5, 114, 80, 206, 19, 48, 6, 203, 244, 114, 10, 127, 4, 142 }, new byte[] { 78, 146, 180, 0, 90, 159, 178, 39, 231, 250, 160, 30, 185, 164, 120, 14, 217, 165, 5, 196, 11, 93, 51, 6, 73, 211, 130, 239, 76, 106, 226, 253, 151, 115, 206, 249, 3, 215, 128, 125, 37, 95, 0, 63, 143, 34, 205, 224, 113, 49, 129, 171, 227, 177, 187, 77, 233, 151, 32, 201, 97, 48, 46, 101, 4, 250, 58, 58, 17, 248, 26, 45, 253, 178, 158, 64, 219, 231, 34, 185, 135, 139, 24, 36, 92, 180, 93, 57, 82, 5, 228, 253, 228, 22, 180, 48, 33, 212, 174, 140, 167, 202, 118, 122, 209, 214, 241, 60, 53, 148, 143, 89, 203, 78, 255, 208, 154, 130, 207, 9, 190, 164, 119, 244, 179, 15, 66, 118 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8e23bac2-4f01-4793-9965-c69ad551de82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("685c3a51-e2ce-4458-b6d0-af11d1ebbc92") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8e23bac2-4f01-4793-9965-c69ad551de82"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("685c3a51-e2ce-4458-b6d0-af11d1ebbc92"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("fab2e156-8c52-46b3-b5fd-5f1bb980128d"), 0, new DateTime(2024, 5, 18, 15, 17, 59, 497, DateTimeKind.Local).AddTicks(5238), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Ays", "Ayd", "", new byte[] { 190, 27, 36, 138, 230, 58, 120, 21, 18, 142, 75, 131, 127, 234, 93, 11, 61, 11, 105, 78, 186, 170, 24, 91, 247, 203, 86, 230, 63, 163, 28, 5, 229, 50, 15, 76, 205, 177, 153, 107, 207, 18, 0, 41, 103, 111, 114, 78, 120, 222, 127, 27, 186, 134, 251, 117, 35, 161, 81, 204, 249, 47, 179, 63 }, new byte[] { 238, 49, 241, 98, 245, 92, 227, 146, 110, 211, 55, 39, 218, 53, 183, 227, 68, 132, 6, 208, 100, 63, 82, 237, 226, 123, 215, 186, 165, 18, 89, 203, 238, 238, 70, 29, 31, 214, 81, 219, 3, 141, 137, 3, 23, 179, 63, 150, 251, 154, 173, 174, 4, 22, 119, 102, 187, 227, 97, 52, 42, 134, 78, 138, 64, 250, 9, 188, 143, 215, 226, 139, 201, 32, 167, 116, 24, 76, 171, 19, 241, 41, 194, 133, 2, 20, 65, 220, 158, 85, 218, 157, 10, 61, 128, 165, 199, 5, 58, 185, 59, 149, 120, 79, 42, 116, 84, 89, 224, 147, 136, 151, 211, 251, 148, 55, 213, 215, 112, 130, 76, 48, 1, 112, 161, 174, 17, 1 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("85142f4b-045a-43a0-8b9a-5a141def5c47"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("fab2e156-8c52-46b3-b5fd-5f1bb980128d") });
        }
    }
}
