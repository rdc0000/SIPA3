using Microsoft.EntityFrameworkCore.Migrations;

namespace SIPA.Migrations
{
    public partial class Dos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Autoservicio");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Articulo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Articulo");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Autoservicio",
                nullable: false,
                defaultValue: 0);
        }
    }
}
