﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiBancoNacion.Models;

namespace WebApiBancoNacion.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201101205521_DbInit")]
    partial class DbInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApiBancoNacion.Models.Billete", b =>
                {
                    b.Property<string>("BilleteID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.HasKey("BilleteID");

                    b.ToTable("Billete");
                });

            modelBuilder.Entity("WebApiBancoNacion.Models.Cotizacion", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BilleteId");

                    b.Property<string>("FechaGuardado");

                    b.Property<string>("FechaObtenido");

                    b.Property<string>("PrecioCompra");

                    b.Property<string>("PrecioVenta");

                    b.HasKey("ID");

                    b.ToTable("Cotizacion");
                });
#pragma warning restore 612, 618
        }
    }
}