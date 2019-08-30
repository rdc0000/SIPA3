using Microsoft.EntityFrameworkCore.Migrations;

namespace SIPA.Migrations
{
    public partial class Tres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "DetallePedido",
                newName: "Total");

            migrationBuilder.AddColumn<int>(
                name: "Monto",
                table: "DetallePedido",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Monto",
                table: "DetallePedido");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "DetallePedido",
                newName: "Precio");
        }
    }
}
