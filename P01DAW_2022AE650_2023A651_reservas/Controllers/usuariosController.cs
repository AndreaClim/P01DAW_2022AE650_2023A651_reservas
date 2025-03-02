﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01DAW_2022AE650_2023A651_reservas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Data;
using LoginRequest = P01DAW_2022AE650_2023A651_reservas.Models.LoginRequest;


namespace P01DAW_2022AE650_2023A651_reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly usuariosContext _usuariosContexto;
        public usuariosController(usuariosContext usuariosContext)
        {
            _usuariosContexto = usuariosContext;
        }

        [HttpPost]
        public async Task<ActionResult<usuarios>> CrearUsuario([FromBody] usuarios nuevoUsuario)
        {
            if (nuevoUsuario == null)
            {
                return BadRequest("Datos inválidos.");
            }


            _usuariosContexto.usuarios.Add(nuevoUsuario);
            await _usuariosContexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = nuevoUsuario.usuario_id }, nuevoUsuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<usuarios>> GetUsuario(int id)
        {
            var usuario = await _usuariosContexto.usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost("login")]
        public async Task<ActionResult> ValidarCredenciales([FromBody] LoginRequest loginRequest)
        {
            
            var usuario = await _usuariosContexto.usuarios
                .FirstOrDefaultAsync(u => u.correo == loginRequest.Correo);

            if (usuario == null)
            {
                return Unauthorized("Usuario no encontrado.");
            }

            if (loginRequest.Contrasena == usuario.contrasena)
            {
                return Ok("Credenciales válidas.");
            }
            else
            {
                return Unauthorized("Credenciales inválidas.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] usuarios usuarioActualizado)
        {
            if (id != usuarioActualizado.usuario_id)
            {
                return BadRequest();
            }

            _usuariosContexto.Entry(usuarioActualizado).State = EntityState.Modified;

            try
            {
                await _usuariosContexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_usuariosContexto.usuarios.Any(e => e.usuario_id == id))
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
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var usuario = await _usuariosContexto.usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _usuariosContexto.usuarios.Remove(usuario);
            await _usuariosContexto.SaveChangesAsync();

            return NoContent();
        }
    }
}



