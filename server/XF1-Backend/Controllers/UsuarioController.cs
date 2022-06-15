using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Models;
using XF1_Backend.Logic;
using XF1_Backend.Requests;
using XF1_Backend.Repositories;

namespace XF1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository repo;

        public UsuarioController(UsuarioDbContext context)
        {
            repo = new UsuarioRepository(context);
        }

        // POST api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {

            // validaciones usuario
            ObjectResult objectResult = Startup.facade.UsuarioValidations(usuario, repo);
            if (objectResult.StatusCode != 200) return objectResult;

            // Encriptar contraseña
            usuario.Contrasena = StringLogicFunctions.EncriptarContrasena(usuario.Contrasena);

            await repo.Complete(usuario);

            // Añadir el jugador a la liga pública
            await repo.AddUsuarioLiga(usuario);

            return Ok();
        }

        // GET api/Usuario/Correos
        [HttpGet("Correos")]
        public async Task<IEnumerable<CorreoUsuario>> GetCorreoUsuarios()
        {
            return await repo.GetCorreoUsuarios();
        }

        // GET api/Usuario/Escuderias
        [HttpGet("Escuderias")]
        public async Task<IEnumerable<EscuderiaUsuario>> GetEscuderiaUsuarios()
        {
            return await repo.GetEscuderiaUsuarios();
        }

        // GET api/Usuario/Perfil/{correo}
        [HttpGet("Perfil/{correo}")]
        public async Task<IEnumerable<UsuarioPerfil>> GetPerfilUsuario(string correo)
        {
            return await repo.GetPerfilUsuario(correo);
        }
    }

}
