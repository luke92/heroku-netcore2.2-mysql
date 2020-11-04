using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiBancoNacion.Migrations
{
    public partial class DbInit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PrecioVenta",
                table: "Cotizacion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrecioCompra",
                table: "Cotizacion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaObtenido",
                table: "Cotizacion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaGuardado",
                table: "Cotizacion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BilleteId",
                table: "Cotizacion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Cotizacion",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Cotizacion",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Cotizacion");

            migrationBuilder.AlterColumn<string>(
                name: "PrecioVenta",
                table: "Cotizacion",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PrecioCompra",
                table: "Cotizacion",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FechaObtenido",
                table: "Cotizacion",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "FechaGuardado",
                table: "Cotizacion",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "BilleteId",
                table: "Cotizacion",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Cotizacion",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
