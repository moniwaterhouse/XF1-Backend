using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Models;
using XF1_Backend.Logic;
using XF1_Backend.Requests;

namespace XF1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioDbContext _context;

        public UsuarioController(UsuarioDbContext context)
        {
            _context = context;
        }

        // POST api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            // revisión de valores nulos
            /*
             * revisar que no existan valores nulos
             */

            // revisión de extensión 
            /*
             * revisar que los valores que se quieren añadir no excedan el máximo de caracteres
             */

            // revisión de repetición de correo electrónico

            /*
             * Realizar un método que asegure que no se repita el correo electrónico con alguno ya existente
             */

            usuario.Contrasena = StringLogicFunctions.EncriptarContrasena(usuario.Contrasena);
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            // Añadir el jugador a la liga pública
            _context.Database.ExecuteSqlInterpolated(UsuarioRequests.anadirUsuarioLiga(usuario.Correo));
            return Ok();
        }

        // GET api/Usuario/Correos
        [HttpGet("Correos")]
        public async Task<IEnumerable<CorreoUsuario>> GetCorreoUsuarios()
        {
            return await _context.Correo.FromSqlRaw(UsuarioRequests.getCorreos).ToListAsync();
        }

        // GET api/Usuario/Escuderias
        [HttpGet("Escuderias")]
        public async Task<IEnumerable<EscuderiaUsuario>> GetEscuderiaUsuarios()
        {
            return await _context.EscuderiaUsuario.FromSqlRaw(UsuarioRequests.getEscuderias).ToListAsync();
        }
    }
}
