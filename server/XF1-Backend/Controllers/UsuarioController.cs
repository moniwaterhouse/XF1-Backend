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
            bool permitido;
            
            // revisión de valores nulos           
            permitido = NullValuesLogicFunctions.ValoresNulosUsuario(usuario);
            if (permitido == false) return Conflict("Se requieren todos los datos del usuario");

            // revisión de la longitud del nombre de usuario
            permitido = StringLogicFunctions.LongitudNombre(usuario.NombreUsuario);
            if (permitido == false) return Conflict("El nombre de usuario debe ser de 1 a 30 caracteres");

            // revisión de la longitud de la contraseña
            permitido = StringLogicFunctions.LongitudContrasena(usuario.Contrasena);
            if (permitido == false) return Conflict("La contraseña del usuario debe ser de 8 caracteres alfanuméricos");                      

            // revisión de repetición de correo
            IEnumerable<CorreoUsuario> correos = await _context.Correo.FromSqlRaw(UsuarioRequests.getCorreos).ToListAsync();
            permitido = StringLogicFunctions.RevisarCorreo(usuario.Correo, correos);
            if (permitido == false) return Conflict("El correa ya ha sido registrado");

            // Encriptar contraseña
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

        // GET api/Usuario/Perfil/{correo}
        [HttpGet("Perfil/{correo}")]
        public async Task<IEnumerable<UsuarioPerfil>> GetPerfilUsuario(string correo)
        {
            return await _context.UsuarioPerfil.FromSqlRaw(UsuarioRequests.getPerfilUsuario(correo)).ToListAsync();
        }
    }

}
