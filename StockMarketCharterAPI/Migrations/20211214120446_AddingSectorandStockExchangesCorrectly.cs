using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMarketCharter.AuthAPI.Migrations
{
    public partial class AddingSectorandStockExchangesCorrectly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    SectorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectorBrief = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.SectorId);
                });

            migrationBuilder.CreateTable(
                name: "Stock Exchange",
                columns: table => new
                {
                    StockExchangeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StockExchangeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockExchangeBrief = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockExchangeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock Exchange", x => x.StockExchangeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "Stock Exchange");
        }
    }
}
