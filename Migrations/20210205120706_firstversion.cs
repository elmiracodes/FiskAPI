using Microsoft.EntityFrameworkCore.Migrations;

namespace FiskAPI.Migrations
{
    public partial class firstversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fisks",
                columns: table => new
                {
                    FiskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Art = table.Column<string>(type: "TEXT", nullable: true),
                    Fakta = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fisks", x => x.FiskId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fisks");
        }
    }
}
