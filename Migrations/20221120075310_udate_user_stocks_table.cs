using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VTBlockBackend.Migrations
{
    public partial class udate_user_stocks_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockId",
                table: "UserStocks");

            migrationBuilder.AddColumn<string>(
                name: "SecId",
                table: "UserStocks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecId",
                table: "UserStocks");

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "UserStocks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
