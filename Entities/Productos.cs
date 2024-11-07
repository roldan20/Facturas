using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoSalinas_Factura.Entities
{
    public class Productos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Codigo { get; set; }
        public string ?Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public Guid FacturaId { get; set; }
        public Facturas? Facturas { get; set; }
        
    }
}
