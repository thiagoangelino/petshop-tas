using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_Petshop.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeAccommodation = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    PetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerName = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerAddress = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerPhone = table.Column<string>(type: "TEXT", nullable: true),
                    Cause = table.Column<string>(type: "TEXT", nullable: true),
                    HeaulthStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    AccommodationPetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "NomeAccommodation", "PetId", "Status" },
                values: new object[] { 1, "Acomodação 1", 2, 0 });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "NomeAccommodation", "PetId", "Status" },
                values: new object[] { 2, "Acomodação 2", 3, 0 });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "NomeAccommodation", "PetId", "Status" },
                values: new object[] { 3, "Acomodação 3", 1, 0 });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "NomeAccommodation", "PetId", "Status" },
                values: new object[] { 4, "Acomodação 4", 0, 0 });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "NomeAccommodation", "PetId", "Status" },
                values: new object[] { 5, "Acomodação 5", 0, 0 });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "NomeAccommodation", "PetId", "Status" },
                values: new object[] { 6, "Acomodação 6", 0, 0 });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "NomeAccommodation", "PetId", "Status" },
                values: new object[] { 7, "Acomodação 7", 0, 0 });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "NomeAccommodation", "PetId", "Status" },
                values: new object[] { 8, "Acomodação 8", 0, 0 });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "NomeAccommodation", "PetId", "Status" },
                values: new object[] { 9, "Acomodação 9", 0, 0 });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "NomeAccommodation", "PetId", "Status" },
                values: new object[] { 10, "Acomodação 10", 0, 0 });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AccommodationPetId", "Cause", "HeaulthStatus", "Name", "OwnerAddress", "OwnerName", "OwnerPhone" },
                values: new object[] { 1, 3, "Febre canina", 0, "Bethoven", "Av. dos Pets, 1234", "Antônio Vasconcelos", "85912345678" });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AccommodationPetId", "Cause", "HeaulthStatus", "Name", "OwnerAddress", "OwnerName", "OwnerPhone" },
                values: new object[] { 2, 1, "Incômodo na coluna vertebral", 0, "Yoda", "Av. dos Jedi, s/n", "Anakim", "85901101010" });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AccommodationPetId", "Cause", "HeaulthStatus", "Name", "OwnerAddress", "OwnerName", "OwnerPhone" },
                values: new object[] { 3, 2, "Perda de visão no olho", 0, "Dalek", "Av. Tardis, 987", "Dora Holanda", "85543215678" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
