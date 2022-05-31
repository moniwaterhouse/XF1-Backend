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
    public class LigaController : ControllerBase
    {
        private readonly LigaDbContext _context;

        public LigaController(LigaDbContext context)
        {
            _context = context;
        }

        // GET api/Liga/PuntajesPublica
        [HttpGet("PuntajesPublica")]
        public async Task<IEnumerable<PuntajesPublica>> GetPuntajesPublica()
        {
            return await _context.PuntajesPublicas.FromSqlRaw(LigaRequests.getPuntajesPublica).ToListAsync();
        }

        // GET api/Liga/PuntajesPublica/{Correo}
        [HttpGet("PuntajesPublica/{correo}")]
        public async Task<IEnumerable<PuntajesPublica>> GetPuntajesPublica(string correo)
        {
            return await _context.PuntajesPublicas.FromSqlRaw(LigaRequests.getPuntajePublicaPorUsuario(correo)).ToListAsync();
        }

        // GET api/Liga/PuntajesPrivada/{Correo}
        [HttpGet("PuntajesPrivada/{correo}")]
        public async Task<IEnumerable<PuntajesPublica>> GetPuntajesPrivada(string correo)
        {
            return await _context.PuntajesPublicas.FromSqlRaw(LigaRequests.getPuntajePrivadaPorUsuario(correo)).ToListAsync();
        }

        // GET api/Liga/InfoPrivada
        [HttpGet("InfoPrivada/{correo}")]
        public async Task<InfoLigaPrivada> GetInfoLigaPrivada(string correo)
        {
            return await _context.InfoLigaPrivadas.FromSqlRaw(LigaRequests.getInfoLigaPrivada(correo)).FirstOrDefaultAsync();
        }

        // GET api/Liga/UsuariosLiga
        [HttpGet("UsuariosLiga/{correo}")]
        public async Task<IEnumerable<UsuariosLiga>> GetUsuariosLiga (string correo)
        {
            return await _context.UsuariosLigas.FromSqlRaw(LigaRequests.getUsuariosLiga(correo)).ToListAsync();
        }
    }
}
