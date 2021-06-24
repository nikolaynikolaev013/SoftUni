using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Migrations
{
    public partial class BetChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Bets",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Bets",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
