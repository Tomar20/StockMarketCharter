using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMarketCharter.AuthAPI.Migrations
{
    public partial class addeddatabasenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurnOver = table.Column<int>(type: "int", nullable: false),
                    CEO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brief = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StockExchangesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Company_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company_Stock Exchange_StockExchangesId",
                        column: x => x.StockExchangesId,
                        principalTable: "Stock Exchange",
                        principalColumn: "StockExchangeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock Price",
                columns: table => new
                {
                    StockCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StockExchangeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentPrice = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock Price", x => x.StockCode);
                    table.ForeignKey(
                        name: "FK_Stock Price_Stock Exchange_StockExchangeId",
                        column: x => x.StockExchangeId,
                        principalTable: "Stock Exchange",
                        principalColumn: "StockExchangeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_SectorId",
                table: "Company",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_StockExchangesId",
                table: "Company",
                column: "StockExchangesId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock Price_StockExchangeId",
                table: "Stock Price",
                column: "StockExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Stock Price");
        }
    }
}
