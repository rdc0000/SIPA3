using Microsoft.EntityFrameworkCore.Migrations;

namespace SIPA.Migrations
{
    public partial class Tres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "Articulo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoProducto",
                table: "Articulo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoProducto",
                table: "Articulo");

            migrationBuilder.AlterColumn<string>(
                name: "Cantidad",
                table: "Articulo",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
