﻿// <auto-generated />
using System;
using GrupoSalinas_Factura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrupoSalinas_Factura.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GrupoSalinas_Factura.Entities.Facturas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Factura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Facturas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0c01ad60-b860-4cc5-9a7a-d2806f9e5622"),
                            Factura = "Factura 0",
                            total = 100m
                        },
                        new
                        {
                            Id = new Guid("d0ebf8eb-ad36-48ce-b0fa-937de9aad8ef"),
                            Factura = "Factura 1",
                            total = 120m
                        });
                });

            modelBuilder.Entity("GrupoSalinas_Factura.Entities.Productos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FacturaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FacturasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FacturasId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("14603b99-cff0-4d69-b5fb-8d906ba919ab"),
                            Cantidad = 4,
                            Codigo = "94959",
                            FacturaId = new Guid("0c01ad60-b860-4cc5-9a7a-d2806f9e5622"),
                            Nombre = "Laptop",
                            Precio = 10m
                        },
                        new
                        {
                            Id = new Guid("f495393e-09cc-4628-8a1e-515a81e47bf3"),
                            Cantidad = 14,
                            Codigo = "94959",
                            FacturaId = new Guid("0c01ad60-b860-4cc5-9a7a-d2806f9e5622"),
                            Nombre = "Laptop Lenovo",
                            Precio = 100m
                        },
                        new
                        {
                            Id = new Guid("198bcd69-a958-48d2-84ab-3722933592e4"),
                            Cantidad = 16,
                            Codigo = "94059",
                            FacturaId = new Guid("d0ebf8eb-ad36-48ce-b0fa-937de9aad8ef"),
                            Nombre = "Laptop Samsung",
                            Precio = 400m
                        });
                });

            modelBuilder.Entity("GrupoSalinas_Factura.Entities.Productos", b =>
                {
                    b.HasOne("GrupoSalinas_Factura.Entities.Facturas", "Facturas")
                        .WithMany("productos")
                        .HasForeignKey("FacturasId");

                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("GrupoSalinas_Factura.Entities.Facturas", b =>
                {
                    b.Navigation("productos");
                });
#pragma warning restore 612, 618
        }
    }
}
