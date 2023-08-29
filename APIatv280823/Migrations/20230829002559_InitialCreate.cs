using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIatv280823.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A = table.Column<float>(type: "real", nullable: false),
                    B = table.Column<float>(type: "real", nullable: false),
                    C = table.Column<float>(type: "real", nullable: false),
                    X1 = table.Column<float>(type: "real", nullable: false),
                    X2 = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equacao");
        }
    }
}
