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
