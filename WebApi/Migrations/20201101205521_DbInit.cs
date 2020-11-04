using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiBancoNacion.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Billete",
                columns: table => new
                {
                    BilleteID = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billete", x => x.BilleteID);
                });

            migrationBuilder.CreateTable(
                name: "Cotizacion",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BilleteId = table.Column<string>(nullable: true),
                    PrecioCompra = table.Column<string>(nullable: true),
                    PrecioVenta = table.Column<string>(nullable: true),
                    FechaObtenido = table.Column<string>(nullable: true),
                    FechaGuardado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizacion", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billete");

            migrationBuilder.DropTable(
                name: "Cotizacion");
        }
    }
}
