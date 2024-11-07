using GrupoSalinas_Factura.Entities;

namespace GrupoSalinas_Factura.Model
{
    public class FacturasModel
    {
        public Guid Id { get; set; }
        public string? Factura { get; set; }
        public decimal total { get; set; }
        public List<Productos> ?productos { get; set; }
    }
}
