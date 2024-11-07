using GrupoSalinas_Factura.Entities;
using GrupoSalinas_Factura.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrupoSalinas_Factura.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FacturaController(ApplicationDbContext contex)
        {
            _context = contex;
        }

        [HttpGet("GetFactura")]
        public async Task<ActionResult<FacturasModel>> GetFactura()
        {
            List<Facturas> facturasList = new List<Facturas>();

            var list = _context.Facturas.ToList();
            
            foreach (Facturas facturas in list)
            {
                var Productos = _context.Productos.Where(x=>x.FacturaId == facturas.Id).ToList();

                facturasList.Add(new Facturas { Id = facturas.Id,
                    productos = Productos, 
                    total = facturas.total, 
                    Factura = facturas.Factura });
           
            }

            return Ok(facturasList);
        }



        [HttpGet("GetFacturaByName")]
        public async Task<ActionResult<FacturasModel>> GetFacturaByName(string Factura)
        {
            List<Facturas> facturasList = new List<Facturas>();

            var list = _context.Facturas.Where(x=>x.Factura == Factura).ToList();

            foreach (Facturas facturas in list)
            {
                var Productos = _context.Productos.Where(x => x.FacturaId == facturas.Id).ToList();

                facturasList.Add(new Facturas
                {
                    Id = facturas.Id,
                    productos = Productos,
                    total = facturas.total,
                    Factura = facturas.Factura
                });

            }

            return Ok(facturasList);
        }




    }
}
