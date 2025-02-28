using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01DAW_2022AE650_2023A651_reservas.Models;
using Microsoft.EntityFrameworkCore;



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

        [HttpPost("espacios")]
        public async Task<ActionResult<espacios>> RegistrarEspacio([FromBody] espacios nuevoEspacio)
        {
            if (nuevoEspacio == null)
            {
                return BadRequest("Datos inválidos.");
            }

            _sucursalesContexto.espacios.Add(nuevoEspacio);
            await _sucursalesContexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEspacio), new { id = nuevoEspacio.espacios_id }, nuevoEspacio);
        }

      
        [HttpGet("espacios/disponibles")]
        public async Task<ActionResult<IEnumerable<espacios>>> GetEspaciosDisponibles()
        {
            var espaciosDisponibles = await _sucursalesContexto.espacios
                .Where(e => e.estado == "Disponible")
                .ToListAsync();

            return espaciosDisponibles;
        }

        // Obtener un espacio de parqueo por ID
        [HttpGet("espacios/{id}")]
        public async Task<ActionResult<espacios>> GetEspacio(int id)
        {
            var espacio = await _sucursalesContexto.espacios.FindAsync(id);

            if (espacio == null)
            {
                return NotFound();
            }

            return espacio;
        }

        [HttpPut("espacios/{id}")]
        public async Task<IActionResult> ActualizarEspacio(int id, [FromBody] espacios espacioActualizado)
        {
            if (id != espacioActualizado.espacios_id)
            {
                return BadRequest();
            }

            _sucursalesContexto.Entry(espacioActualizado).State = EntityState.Modified;
            await _sucursalesContexto.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("espacios/{id}")]
        public async Task<IActionResult> EliminarEspacio(int id)
        {
            var espacio = await _sucursalesContexto.espacios.FindAsync(id);
            if (espacio == null)
            {
                return NotFound();
            }

            _sucursalesContexto.espacios.Remove(espacio);
            await _sucursalesContexto.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("espacios/reservados/{fecha}")]
        public async Task<ActionResult<IEnumerable<espacios>>> GetEspaciosReservadosPorFecha(DateTime fecha)
        {
            var espaciosReservados = await _sucursalesContexto.espacios
                .Where(e => e.estado == "Ocupado" && e.fecha == fecha)
                .ToListAsync();

            return espaciosReservados;
        }

        // 4. Mostrar espacios reservados entre dos fechas
        [HttpGet("espacios/reservados")]
        public async Task<ActionResult<IEnumerable<espacios>>> GetEspaciosReservadosEntreFechas([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            var espaciosReservados = await _sucursalesContexto.espacios
                .Where(e => e.estado == "Ocupado" && e.fecha >= fechaInicio && e.fecha <= fechaFin)
                .ToListAsync();

            return espaciosReservados;
        }

    }
}

