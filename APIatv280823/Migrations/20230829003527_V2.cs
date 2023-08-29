using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIatv280823.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Delta",
                table: "Equacao",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delta",
                table: "Equacao");
        }
    }
}
