using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiNETAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CombustionTaxis",
                columns: table => new
                {
                    CombustionTaxiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarDoor = table.Column<int>(type: "int", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGearBox = table.Column<bool>(type: "bit", nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    TravelRange = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombustionTaxis", x => x.CombustionTaxiID);
                });

            migrationBuilder.CreateTable(
                name: "ElectricTaxis",
                columns: table => new
                {
                    electricTaxiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarDoor = table.Column<int>(type: "int", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGearBox = table.Column<bool>(type: "bit", nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    TravelRange = table.Column<int>(type: "int", nullable: false),
                    batteryCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricTaxis", x => x.electricTaxiID);
                });

            migrationBuilder.CreateTable(
                name: "TaxiDrivers",
                columns: table => new
                {
                    TaxiDriverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsManualLicence = table.Column<bool>(type: "bit", nullable: false),
                    XCoordinates = table.Column<int>(type: "int", nullable: false),
                    YCoordinates = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiDrivers", x => x.TaxiDriverID);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XStartCoordinates = table.Column<int>(type: "int", nullable: false),
                    XFinishCoordinates = table.Column<int>(type: "int", nullable: false),
                    YStartCoordinates = table.Column<int>(type: "int", nullable: false),
                    YFinishCoordinates = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CombustionTaxis");

            migrationBuilder.DropTable(
                name: "ElectricTaxis");

            migrationBuilder.DropTable(
                name: "TaxiDrivers");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
