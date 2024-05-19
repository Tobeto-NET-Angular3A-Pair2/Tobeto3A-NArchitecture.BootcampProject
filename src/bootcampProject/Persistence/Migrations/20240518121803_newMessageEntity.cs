using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newMessageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8398a7a5-4864-4959-a533-3a9ba4de000a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b2f9850-45d7-4f60-be3e-2ed90232d0e6"));

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Messages.Admin", null },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Messages.Read", null },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Messages.Write", null },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Messages.Create", null },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Messages.Update", null },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Messages.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DateOfBirth", "DeletedDate", "Email", "FirstName", "LastName", "NationalIdentity", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[] { new Guid("fab2e156-8c52-46b3-b5fd-5f1bb980128d"), 0, new DateTime(2024, 5, 18, 15, 17, 59, 497, DateTimeKind.Local).AddTicks(5238), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Ays", "Ayd", "", new byte[] { 190, 27, 36, 138, 230, 58, 120, 21, 18, 142, 75, 131, 127, 234, 93, 11, 61, 11, 105, 78, 186, 170, 24, 91, 247, 203, 86, 230, 63, 163, 28, 5, 229, 50, 15, 76, 205, 177, 153, 107, 207, 18, 0, 41, 103, 111, 114, 78, 120, 222, 127, 27, 186, 134, 251, 117, 35, 161, 81, 204, 249, 47, 179, 63 }, new byte[] { 238, 49, 241, 98, 245, 92, 227, 146, 110, 211, 55, 39, 218, 53, 183, 227, 68, 132, 6, 208, 100, 63, 82, 237, 226, 123, 215, 186, 165, 18, 89, 203, 238, 238, 70, 29, 31, 214, 81, 219, 3, 141, 137, 3, 23, 179, 63, 150, 251, 154, 173, 174, 4, 22, 119, 102, 187, 227, 97, 52, 42, 134, 78, 138, 64, 250, 9, 188, 143, 215, 226, 139, 201, 32, 167, 116, 24, 76, 171, 19, 241, 41, 194, 133, 2, 20, 65, 220, 158, 85, 218, 157, 10, 61, 128, 165, 199, 5, 58, 185, 59, 149, 120, 79, 42, 116, 84, 89, 224, 147, 136, 151, 211, 251, 148, 55, 213, 215, 112, 130, 76, 48, 1, 112, 161, 174, 17, 1 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("85142f4b-045a-43a0-8b9a-5a141def5c47"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("fab2e156-8c52-46b3-b5fd-5f1bb980128d") });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 83);

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
                values: new object[] { new Guid("2b2f9850-45d7-4f60-be3e-2ed90232d0e6"), 0, new DateTime(2024, 4, 30, 20, 47, 24, 839, DateTimeKind.Local).AddTicks(7222), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Ays", "Ayd", "", new byte[] { 23, 123, 167, 133, 193, 116, 177, 247, 251, 146, 194, 176, 97, 96, 94, 92, 16, 234, 148, 42, 91, 163, 202, 241, 10, 175, 245, 155, 19, 40, 66, 164, 249, 113, 73, 20, 182, 29, 129, 223, 228, 225, 34, 74, 182, 210, 66, 45, 158, 188, 228, 58, 15, 87, 60, 224, 134, 96, 109, 143, 22, 13, 93, 18 }, new byte[] { 165, 101, 87, 46, 253, 244, 32, 85, 87, 134, 208, 113, 34, 140, 115, 136, 255, 31, 122, 164, 7, 135, 174, 154, 98, 43, 61, 70, 119, 236, 180, 88, 155, 31, 114, 47, 243, 128, 13, 82, 166, 159, 136, 92, 173, 5, 94, 252, 138, 183, 166, 244, 128, 150, 30, 149, 237, 135, 117, 227, 126, 39, 95, 161, 213, 38, 61, 128, 139, 221, 252, 140, 217, 78, 131, 23, 203, 24, 68, 130, 172, 10, 206, 117, 20, 201, 144, 148, 15, 213, 33, 201, 64, 178, 60, 215, 91, 55, 81, 67, 214, 95, 239, 74, 2, 226, 224, 22, 133, 192, 210, 46, 230, 235, 142, 122, 94, 72, 249, 95, 224, 223, 74, 46, 163, 214, 63, 189 }, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8398a7a5-4864-4959-a533-3a9ba4de000a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("2b2f9850-45d7-4f60-be3e-2ed90232d0e6") });
        }
    }
}
