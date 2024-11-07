using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoSalinas_Factura.Entities
{
    public class Facturas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string ?Factura { get;set; }
        public decimal total { get; set; }
        public List<Productos> ?productos { get; set; }

    }
}
