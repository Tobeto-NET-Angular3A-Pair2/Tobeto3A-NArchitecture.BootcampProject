using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BootcampComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("330675ac-deb4-41b6-8bb0-8c25e2b1da37")
            );

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d4d2aab-30cd-4ff3-97ad-791a39a28ce8")
            );

            migrationBuilder.CreateTable(
                name: "BootcampComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BootcampId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BootcampComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BootcampComments_Bootcamps_BootcampId",
                        column: x => x.BootcampId,
                        principalTable: "Bootcamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_BootcampComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BootcampComments.Admin", null },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BootcampComments.Read", null },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BootcampComments.Write", null },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BootcampComments.Create", null },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BootcampComments.Update", null },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BootcampComments.Delete", null }
                }
            );

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 26, 0, 32, 51, 226, DateTimeKind.Local).AddTicks(7170)
            );

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[]
                {
                    "Id",
                    "AuthenticatorType",
                    "CreatedDate",
                    "DateOfBirth",
                    "DeletedDate",
                    "Email",
                    "FirstName",
                    "LastName",
                    "NationalIdentity",
                    "PasswordHash",
                    "PasswordSalt",
                    "UpdatedDate",
                    "UserName"
                },
                values: new object[]
                {
                    new Guid("65e06f38-55d1-4739-a7a0-8b1b44a7f453"),
                    0,
                    new DateTime(2024, 5, 26, 0, 32, 51, 258, DateTimeKind.Local).AddTicks(1364),
                    new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    null,
                    "narch@kodlama.io",
                    "Ays",
                    "Ayd",
                    "",
                    new byte[]
                    {
                        147,
                        176,
                        192,
                        55,
                        169,
                        130,
                        104,
                        208,
                        65,
                        39,
                        198,
                        156,
                        182,
                        19,
                        238,
                        221,
                        39,
                        56,
                        181,
                        140,
                        176,
                        34,
                        9,
                        119,
                        50,
                        161,
                        94,
                        6,
                        240,
                        135,
                        212,
                        149,
                        119,
                        150,
                        78,
                        29,
                        241,
                        177,
                        235,
                        204,
                        46,
                        90,
                        48,
                        212,
                        188,
                        4,
                        186,
                        108,
                        31,
                        123,
                        255,
                        130,
                        20,
                        254,
                        162,
                        156,
                        240,
                        220,
                        229,
                        7,
                        113,
                        15,
                        109,
                        53
                    },
                    new byte[]
                    {
                        53,
                        135,
                        18,
                        249,
                        77,
                        41,
                        4,
                        163,
                        32,
                        236,
                        172,
                        155,
                        235,
                        109,
                        144,
                        52,
                        104,
                        228,
                        93,
                        102,
                        7,
                        245,
                        26,
                        107,
                        247,
                        235,
                        68,
                        122,
                        129,
                        117,
                        6,
                        80,
                        23,
                        236,
                        249,
                        148,
                        7,
                        100,
                        250,
                        60,
                        23,
                        26,
                        65,
                        119,
                        111,
                        208,
                        79,
                        22,
                        180,
                        57,
                        132,
                        235,
                        216,
                        235,
                        175,
                        42,
                        0,
                        197,
                        130,
                        86,
                        58,
                        246,
                        46,
                        130,
                        232,
                        108,
                        190,
                        71,
                        107,
                        152,
                        114,
                        9,
                        16,
                        120,
                        198,
                        114,
                        2,
                        142,
                        139,
                        190,
                        109,
                        238,
                        132,
                        190,
                        56,
                        130,
                        140,
                        68,
                        13,
                        223,
                        239,
                        134,
                        75,
                        180,
                        135,
                        187,
                        37,
                        216,
                        177,
                        156,
                        70,
                        227,
                        200,
                        80,
                        54,
                        248,
                        122,
                        177,
                        212,
                        134,
                        104,
                        12,
                        78,
                        102,
                        197,
                        50,
                        190,
                        250,
                        245,
                        94,
                        254,
                        62,
                        53,
                        84,
                        174,
                        159,
                        188,
                        30
                    },
                    null,
                    "admin"
                }
            );

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[]
                {
                    new Guid("7255643e-068e-4de3-8aa1-f62184b4fd38"),
                    new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    null,
                    1,
                    null,
                    new Guid("65e06f38-55d1-4739-a7a0-8b1b44a7f453")
                }
            );

            migrationBuilder.CreateIndex(name: "IX_BootcampComments_BootcampId", table: "BootcampComments", column: "BootcampId");

            migrationBuilder.CreateIndex(name: "IX_BootcampComments_UserId", table: "BootcampComments", column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "BootcampComments");

            migrationBuilder.DeleteData(table: "OperationClaims", keyColumn: "Id", keyValue: 120);

            migrationBuilder.DeleteData(table: "OperationClaims", keyColumn: "Id", keyValue: 121);

            migrationBuilder.DeleteData(table: "OperationClaims", keyColumn: "Id", keyValue: 122);

            migrationBuilder.DeleteData(table: "OperationClaims", keyColumn: "Id", keyValue: 123);

            migrationBuilder.DeleteData(table: "OperationClaims", keyColumn: "Id", keyValue: 124);

            migrationBuilder.DeleteData(table: "OperationClaims", keyColumn: "Id", keyValue: 125);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7255643e-068e-4de3-8aa1-f62184b4fd38")
            );

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("65e06f38-55d1-4739-a7a0-8b1b44a7f453")
            );

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 16, 52, 40, 276, DateTimeKind.Local).AddTicks(9762)
            );

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[]
                {
                    "Id",
                    "AuthenticatorType",
                    "CreatedDate",
                    "DateOfBirth",
                    "DeletedDate",
                    "Email",
                    "FirstName",
                    "LastName",
                    "NationalIdentity",
                    "PasswordHash",
                    "PasswordSalt",
                    "UpdatedDate",
                    "UserName"
                },
                values: new object[]
                {
                    new Guid("8d4d2aab-30cd-4ff3-97ad-791a39a28ce8"),
                    0,
                    new DateTime(2024, 5, 21, 16, 52, 40, 278, DateTimeKind.Local).AddTicks(7746),
                    new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    null,
                    "narch@kodlama.io",
                    "Ays",
                    "Ayd",
                    "",
                    new byte[]
                    {
                        189,
                        130,
                        142,
                        7,
                        100,
                        36,
                        216,
                        29,
                        16,
                        40,
                        176,
                        195,
                        25,
                        108,
                        66,
                        133,
                        160,
                        78,
                        158,
                        190,
                        165,
                        121,
                        109,
                        191,
                        211,
                        92,
                        1,
                        170,
                        54,
                        14,
                        164,
                        123,
                        41,
                        57,
                        17,
                        225,
                        14,
                        153,
                        29,
                        135,
                        145,
                        255,
                        127,
                        247,
                        2,
                        82,
                        245,
                        217,
                        209,
                        76,
                        215,
                        97,
                        16,
                        242,
                        133,
                        114,
                        139,
                        45,
                        110,
                        44,
                        161,
                        231,
                        15,
                        161
                    },
                    new byte[]
                    {
                        150,
                        73,
                        134,
                        141,
                        192,
                        88,
                        156,
                        13,
                        207,
                        172,
                        116,
                        116,
                        186,
                        164,
                        159,
                        221,
                        140,
                        115,
                        66,
                        200,
                        75,
                        198,
                        237,
                        164,
                        230,
                        36,
                        59,
                        27,
                        214,
                        5,
                        217,
                        142,
                        121,
                        178,
                        230,
                        193,
                        111,
                        226,
                        78,
                        167,
                        172,
                        24,
                        120,
                        195,
                        98,
                        100,
                        88,
                        154,
                        222,
                        37,
                        64,
                        80,
                        131,
                        39,
                        25,
                        171,
                        129,
                        75,
                        220,
                        172,
                        103,
                        78,
                        217,
                        165,
                        26,
                        199,
                        33,
                        49,
                        73,
                        154,
                        214,
                        215,
                        106,
                        229,
                        167,
                        178,
                        196,
                        123,
                        237,
                        36,
                        154,
                        194,
                        205,
                        34,
                        89,
                        80,
                        103,
                        104,
                        127,
                        142,
                        185,
                        165,
                        40,
                        128,
                        66,
                        198,
                        91,
                        45,
                        169,
                        195,
                        75,
                        208,
                        162,
                        139,
                        170,
                        12,
                        110,
                        7,
                        103,
                        20,
                        146,
                        164,
                        55,
                        116,
                        197,
                        10,
                        211,
                        214,
                        175,
                        225,
                        152,
                        43,
                        101,
                        84,
                        25,
                        89,
                        66,
                        252
                    },
                    null,
                    "admin"
                }
            );

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[]
                {
                    new Guid("330675ac-deb4-41b6-8bb0-8c25e2b1da37"),
                    new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    null,
                    1,
                    null,
                    new Guid("8d4d2aab-30cd-4ff3-97ad-791a39a28ce8")
                }
            );
        }
    }
}
