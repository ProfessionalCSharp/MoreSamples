using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnumMapping.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookupValues",
                columns: table => new
                {
                    LookupValueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomValue = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupValues", x => x.LookupValueId);
                });

            migrationBuilder.CreateTable(
                name: "SampleData",
                columns: table => new
                {
                    SomeDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(maxLength: 20, nullable: true),
                    CustomValue = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleData", x => x.SomeDataId);
                });

            migrationBuilder.CreateTable(
                name: "SomeData2",
                columns: table => new
                {
                    SomeData2Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    LookupValueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SomeData2", x => x.SomeData2Id);
                    table.ForeignKey(
                        name: "FK_SomeData2_LookupValues_LookupValueId",
                        column: x => x.LookupValueId,
                        principalTable: "LookupValues",
                        principalColumn: "LookupValueId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "LookupValues",
                columns: new[] { "LookupValueId", "CustomValue" },
                values: new object[,]
                {
                    { 1, "One" },
                    { 2, "Two" },
                    { 3, "Three" }
                });

            migrationBuilder.InsertData(
                table: "SampleData",
                columns: new[] { "SomeDataId", "CustomValue", "Text" },
                values: new object[,]
                {
                    { 1, "One", "hello" },
                    { 2, "Two", "world" }
                });

            migrationBuilder.InsertData(
                table: "SomeData2",
                columns: new[] { "SomeData2Id", "LookupValueId", "Text" },
                values: new object[] { 1, 1, "hello" });

            migrationBuilder.InsertData(
                table: "SomeData2",
                columns: new[] { "SomeData2Id", "LookupValueId", "Text" },
                values: new object[] { 2, 2, "world" });

            migrationBuilder.CreateIndex(
                name: "IX_SomeData2_LookupValueId",
                table: "SomeData2",
                column: "LookupValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleData");

            migrationBuilder.DropTable(
                name: "SomeData2");

            migrationBuilder.DropTable(
                name: "LookupValues");
        }
    }
}
