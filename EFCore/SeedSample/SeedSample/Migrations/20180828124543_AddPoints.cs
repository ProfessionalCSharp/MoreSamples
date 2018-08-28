using Microsoft.EntityFrameworkCore.Migrations;

namespace SeedSample.Migrations
{
    public partial class AddPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Racers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Racers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Points",
                value: 231);

            migrationBuilder.UpdateData(
                table: "Racers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Points",
                value: 214);

            migrationBuilder.UpdateData(
                table: "Racers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Points",
                value: 146);

            migrationBuilder.UpdateData(
                table: "Racers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Points",
                value: 144);

            migrationBuilder.UpdateData(
                table: "Racers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Points",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Racers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Points",
                value: 118);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Racers");
        }
    }
}
