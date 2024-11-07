using GrupoSalinas_Factura.Entities;
using GrupoSalinas_Factura.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace GrupoSalinas_Factura.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductoController(ApplicationDbContext contex)
        {
            _context = contex;
        }

        [HttpGet("GetProducto")]
        public async Task<ActionResult<List<Productos>>> GetProducto()
        {
            var list = _context.Productos.GetAsyncEnumerator();
            return Ok(list);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<List<Productos>>> GetById(Guid Id)
        {
            var model = _context.Productos.FindAsync(Id);
            return Ok(model);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Productos>> AddProducto(Productos productos)
        {
           
           var producto =  _context.Productos.Add(productos);
            await _context.SaveChangesAsync();

            return Ok(producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(Guid id, Productos productos)
        {
            if (id != productos.Id)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Productos.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(Guid id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
