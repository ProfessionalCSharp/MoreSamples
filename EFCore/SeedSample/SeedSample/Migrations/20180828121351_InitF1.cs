using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeedSample.Migrations
{
    public partial class InitF1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Racers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Team = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Racers",
                columns: new[] { "Id", "Name", "Team" },
                values: new object[,]
                {
                    { 1, "Lewis Hamilton", "Mercedes" },
                    { 2, "Sebastian Vettel", "Ferrari" },
                    { 3, "Kimi Räikkönen", "Ferrari" },
                    { 4, "Valtteri Bottas", "Mercedes" },
                    { 5, "Max Verstappen", "Red Bull Racing" },
                    { 6, "Daniel Ricciardo", "Red Bull Racing" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Racers");
        }
    }
}
