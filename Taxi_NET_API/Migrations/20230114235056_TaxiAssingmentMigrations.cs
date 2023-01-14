using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiNETAPI.Migrations
{
    /// <inheritdoc />
    public partial class TaxiAssingmentMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxiAssingments");

            migrationBuilder.CreateTable(
                name: "DriverChoices",
                columns: table => new
                {
                    DriverChoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxiDriverID = table.Column<int>(type: "int", nullable: false),
                    TripID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverChoices", x => x.DriverChoiceID);
                });

            migrationBuilder.CreateTable(
                name: "TaxiAssignments",
                columns: table => new
                {
                    TaxiAssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxiDriverID = table.Column<int>(type: "int", nullable: false),
                    IsElectric = table.Column<bool>(type: "bit", nullable: false),
                    TaxiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiAssignments", x => x.TaxiAssignmentID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverChoices");

            migrationBuilder.DropTable(
                name: "TaxiAssignments");

            migrationBuilder.CreateTable(
                name: "TaxiAssingments",
                columns: table => new
                {
                    TaxiAssingmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsElectric = table.Column<bool>(type: "bit", nullable: false),
                    TaxiDriverID = table.Column<int>(type: "int", nullable: false),
                    TaxiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiAssingments", x => x.TaxiAssingmentID);
                });
        }
    }
}
