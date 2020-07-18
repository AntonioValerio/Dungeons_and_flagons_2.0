using Microsoft.EntityFrameworkCore.Migrations;

namespace Dungeons_And_Flagons.Migrations
{
    public partial class AddedSpell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "Spellcasting",
                table: "Subraces",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Subraces",
                keyColumn: "ID",
                keyValue: 4,
                column: "Spellcasting",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Spellcasting",
                table: "Subraces");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
