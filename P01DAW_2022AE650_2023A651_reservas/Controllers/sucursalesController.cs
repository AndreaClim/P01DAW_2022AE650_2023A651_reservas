using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01DAW_2022AE650_2023A651_reservas.Models;
using Microsoft.EntityFrameworkCore;
using L01_2022AE650_2023CA651.Models;

namespace P01DAW_2022AE650_2023A651_reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sucursalesController : ControllerBase
    {
        private readonly sucursalesContext _sucursalesContexto;
        public sucursalesController(sucursalesContext sucursalesContext)
        {
            _sucursalesContexto = sucursalesContext;
        }

        [HttpPost]
        public async Task<ActionResult<sucursales>> CrearSucursal([FromBody] sucursales nuevaSucursal)
        {
            if (nuevaSucursal == null)
            {
                return BadRequest("Datos inválidos.");
            }

            _sucursalesContexto.sucursales.Add(nuevaSucursal);
            await _sucursalesContexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSucursal), new { id = nuevaSucursal.sucursales_id }, nuevaSucursal);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<sucursales>> GetSucursal(int id)
        {
            var sucursal = await _sucursalesContexto.sucursales.FindAsync(id);

            if (sucursal == null)
            {
                return NotFound();
            }

            return sucursal;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<sucursales>>> GetSucursales()
        {
            return await _sucursalesContexto.sucursales.ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarSucursal(int id, [FromBody] sucursales sucursalActualizada)
        {
            if (id != sucursalActualizada.sucursales_id)
            {
                return BadRequest();
            }

            _sucursalesContexto.Entry(sucursalActualizada).State = EntityState.Modified;
            await _sucursalesContexto.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarSucursal(int id)
        {
            var sucursal = await _sucursalesContexto.sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            _sucursalesContexto.sucursales.Remove(sucursal);
            await _sucursalesContexto.SaveChangesAsync();

            return NoContent();
        }

        
    }
}

