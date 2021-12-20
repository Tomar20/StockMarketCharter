using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMarketCharter.AuthAPI.Migrations
{
    public partial class addingipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IPO",
                columns: table => new
                {
                    IPOId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StockExchangeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PricePerShare = table.Column<int>(type: "int", nullable: false),
                    TotalNumberOfShare = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPO", x => x.IPOId);
                    table.ForeignKey(
                        name: "FK_IPO_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IPO_Stock Exchange_StockExchangeId",
                        column: x => x.StockExchangeId,
                        principalTable: "Stock Exchange",
                        principalColumn: "StockExchangeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IPO_CompanyId",
                table: "IPO",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_IPO_StockExchangeId",
                table: "IPO",
                column: "StockExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPO");
        }
    }
}
