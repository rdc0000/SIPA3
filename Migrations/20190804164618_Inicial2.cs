using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIPA.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transporte",
                columns: table => new
                {
                    TransporteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoVehiculo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporte", x => x.TransporteID);
                });

            migrationBuilder.CreateTable(
                name: "Domicilio",
                columns: table => new
                {
                    DomicilioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransporteID = table.Column<int>(nullable: false),
                    HoraFecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilio", x => x.DomicilioID);
                    table.ForeignKey(
                        name: "FK_Domicilio_Transporte_TransporteID",
                        column: x => x.TransporteID,
                        principalTable: "Transporte",
                        principalColumn: "TransporteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_TransporteID",
                table: "Domicilio",
                column: "TransporteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Domicilio");

            migrationBuilder.DropTable(
                name: "Transporte");
        }
    }
}
