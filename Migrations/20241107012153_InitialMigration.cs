using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrupoSalinas_Factura.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Factura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FacturaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacturasId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Facturas_FacturasId",
                        column: x => x.FacturasId,
                        principalTable: "Facturas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Facturas",
                columns: new[] { "Id", "Factura", "total" },
                values: new object[,]
                {
                    { new Guid("0c01ad60-b860-4cc5-9a7a-d2806f9e5622"), "Factura 0", 100m },
                    { new Guid("d0ebf8eb-ad36-48ce-b0fa-937de9aad8ef"), "Factura 1", 120m }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Cantidad", "Codigo", "FacturaId", "FacturasId", "Nombre", "Precio" },
                values: new object[,]
                {
                    { new Guid("14603b99-cff0-4d69-b5fb-8d906ba919ab"), 4, "94959", new Guid("0c01ad60-b860-4cc5-9a7a-d2806f9e5622"), null, "Laptop", 10m },
                    { new Guid("198bcd69-a958-48d2-84ab-3722933592e4"), 16, "94059", new Guid("d0ebf8eb-ad36-48ce-b0fa-937de9aad8ef"), null, "Laptop Samsung", 400m },
                    { new Guid("f495393e-09cc-4628-8a1e-515a81e47bf3"), 14, "94959", new Guid("0c01ad60-b860-4cc5-9a7a-d2806f9e5622"), null, "Laptop Lenovo", 100m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FacturasId",
                table: "Productos",
                column: "FacturasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Facturas");
        }
    }
}
