using Microsoft.EntityFrameworkCore.Migrations;

namespace SIPA.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedido_Articulo_ArticuloID",
                table: "DetallePedido");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedido_Pedido_PedidoID",
                table: "DetallePedido");

            migrationBuilder.DropColumn(
                name: "Monto",
                table: "DetallePedido");

            migrationBuilder.DropColumn(
                name: "PrecioVenta",
                table: "DetallePedido");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoID",
                table: "DetallePedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ArticuloID",
                table: "DetallePedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioTotal",
                table: "DetallePedido",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "DetallePedido",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedido_Articulo_ArticuloID",
                table: "DetallePedido",
                column: "ArticuloID",
                principalTable: "Articulo",
                principalColumn: "ArticuloID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedido_Pedido_PedidoID",
                table: "DetallePedido",
                column: "PedidoID",
                principalTable: "Pedido",
                principalColumn: "PedidoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedido_Articulo_ArticuloID",
                table: "DetallePedido");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedido_Pedido_PedidoID",
                table: "DetallePedido");

            migrationBuilder.DropColumn(
                name: "PrecioTotal",
                table: "DetallePedido");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "DetallePedido");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoID",
                table: "DetallePedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArticuloID",
                table: "DetallePedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Monto",
                table: "DetallePedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrecioVenta",
                table: "DetallePedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedido_Articulo_ArticuloID",
                table: "DetallePedido",
                column: "ArticuloID",
                principalTable: "Articulo",
                principalColumn: "ArticuloID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedido_Pedido_PedidoID",
                table: "DetallePedido",
                column: "PedidoID",
                principalTable: "Pedido",
                principalColumn: "PedidoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
