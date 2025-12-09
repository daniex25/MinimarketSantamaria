using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimarketSantamaria.Data;
using MinimarketSantamaria.Models.Entidades;

namespace MinimarketSantamaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasAPIController : Controller
    {
        private readonly MinimarketSantamariaContext _context;
        public VentasAPIController(MinimarketSantamariaContext context)
        {
            _context = context;
        }
        //Get: api/ProductoApi

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> GetVentas()
        {
            return await _context.Ventas.ToListAsync();
        }

        //Get: api/OperacionesApi/5

        [HttpGet("{id}")]
        public async Task<ActionResult<Ventas>> GetVentas(int id)
        {
            var entidad = await _context.Ventas.FindAsync(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;

        }

        //Post:api/ProductoAPI
        [HttpPost]
        public async Task<ActionResult<Ventas>> PostVentas(Ventas entidad)
        {
            _context.Ventas.Add(entidad);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVentas), new { id = entidad.IdVentas }, entidad);
        }

        //Put : api/ProductoAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentas(int id, Ventas entidad)
        {
            if (id != entidad.IdVentas)
            {
                return BadRequest();

            }
            _context.Entry(entidad).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Ventas.Any(e => e.IdVentas == id))
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

        //Delete: api/ProductoApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentas(int id)
        {
            var entidad = await _context.Ventas.FindAsync(id);
            if (entidad == null)
                return NotFound();
            _context.Ventas.Remove(entidad);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
