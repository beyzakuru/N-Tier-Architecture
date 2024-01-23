using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTierArchitecture.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Journeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureLocation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ArrivalLocation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    JourneyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TCNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JourneyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_Journeys_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassportNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    JourneyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passports_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Journeys",
                columns: new[] { "Id", "ArrivalLocation", "CreatedDate", "DepartureLocation", "JourneyDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Ankara", new DateTime(2024, 1, 14, 13, 15, 13, 711, DateTimeKind.Local).AddTicks(6779), "İstanbul", new DateTime(2024, 1, 12, 9, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "Trabzon", new DateTime(2024, 1, 14, 13, 15, 13, 711, DateTimeKind.Local).AddTicks(6791), "Antalya", new DateTime(2024, 1, 15, 13, 45, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "Muğla", new DateTime(2024, 1, 14, 13, 15, 13, 711, DateTimeKind.Local).AddTicks(6792), "Rize", new DateTime(2024, 1, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "Çanakkale", new DateTime(2024, 1, 14, 13, 15, 13, 711, DateTimeKind.Local).AddTicks(6794), "Ankara", new DateTime(2024, 1, 23, 23, 15, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "Id", "CreatedDate", "EMail", "FirstName", "Gender", "JourneyId", "LastName", "Password", "TCNo", "Telephone", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 14, 13, 15, 13, 711, DateTimeKind.Local).AddTicks(7108), "beyzakuru@hotmail.com", "Beyza", "Kadın", 1, "Kuru", "hello61", "11111111111", "05363453435", null },
                    { 2, new DateTime(2024, 1, 14, 13, 15, 13, 711, DateTimeKind.Local).AddTicks(7111), "bahadircetin@hotmail.com", "Bahadır", "Erkek", 2, "Çetin", "gymgyme", "22222222222", "05443903930", null },
                    { 3, new DateTime(2024, 1, 14, 13, 15, 13, 711, DateTimeKind.Local).AddTicks(7112), "silaguven@hotmail.com", "Sıla", "Kadın", 3, "Güven", "beauty", "33333333333", "05438828882", null },
                    { 4, new DateTime(2024, 1, 14, 13, 15, 13, 711, DateTimeKind.Local).AddTicks(7114), "cantetik@hotmail.com", "Can", "Erkek", 4, "Tetik", "joker", "44444444444", "05374634643", null }
                });

            migrationBuilder.InsertData(
                table: "Passports",
                columns: new[] { "Id", "ExpiryDate", "JourneyId", "PassengerId", "PassportNo" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 23, 12, 36, 0, 0, DateTimeKind.Unspecified), 1, 1, "U111111111" },
                    { 2, new DateTime(2025, 2, 13, 13, 42, 0, 0, DateTimeKind.Unspecified), 2, 2, "U222222222" },
                    { 3, new DateTime(2025, 3, 11, 16, 12, 0, 0, DateTimeKind.Unspecified), 3, 3, "U333333333" },
                    { 4, new DateTime(2025, 4, 2, 8, 50, 0, 0, DateTimeKind.Unspecified), 4, 4, "U444444444" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_JourneyId",
                table: "Passengers",
                column: "JourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_TCNo",
                table: "Passengers",
                column: "TCNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passports_Id",
                table: "Passports",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passports_PassengerId",
                table: "Passports",
                column: "PassengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Journeys");
        }
    }
}
