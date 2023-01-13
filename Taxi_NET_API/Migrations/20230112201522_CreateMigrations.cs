using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiNETAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxiAssingments",
                columns: table => new
                {
                    TaxiAssingmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxiDriverID = table.Column<int>(type: "int", nullable: false),
                    IsElectric = table.Column<bool>(type: "bit", nullable: false),
                    TaxiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiAssingments", x => x.TaxiAssingmentID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxiAssingments");
        }
    }
}
