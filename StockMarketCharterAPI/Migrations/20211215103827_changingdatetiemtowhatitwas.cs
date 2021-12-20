using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockMarketCharter.AuthAPI.Migrations
{
    public partial class changingdatetiemtowhatitwas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Stock Price");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Stock Price");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "IPO");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "IPO");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Stock Price",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "IPO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Stock Price");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "IPO");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Stock Price",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Stock Price",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "IPO",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "IPO",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
