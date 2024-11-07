using GrupoSalinas_Factura.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace GrupoSalinas_Factura
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Facturas>(b =>
            {
                b.HasData(
                    new Facturas { Id = Guid.Parse("0c01ad60-b860-4cc5-9a7a-d2806f9e5622"), Factura = "Factura 0", total = 100 },
                    new Facturas { Id = Guid.Parse("d0ebf8eb-ad36-48ce-b0fa-937de9aad8ef"), Factura = "Factura 1", total = 120 });
                  
            });

            modelBuilder.Entity<Productos>(b =>
            {
                b.HasData(
                    new Productos { Id = Guid.NewGuid(), Precio = 10, Cantidad = 4, Nombre = "Laptop", Codigo = "94959", FacturaId = Guid.Parse("0c01ad60-b860-4cc5-9a7a-d2806f9e5622") },
                    new Productos { Id = Guid.NewGuid(), Precio = 100, Cantidad = 14, Nombre = "Laptop Lenovo", Codigo = "94959", FacturaId = Guid.Parse("0c01ad60-b860-4cc5-9a7a-d2806f9e5622") },
                    new Productos { Id = Guid.NewGuid(), Precio = 400, Cantidad = 16, Nombre = "Laptop Samsung", Codigo = "94059", FacturaId = Guid.Parse("d0ebf8eb-ad36-48ce-b0fa-937de9aad8ef") }); ;
            });
        }

        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<Productos> Productos { get; set; }
    }
}
