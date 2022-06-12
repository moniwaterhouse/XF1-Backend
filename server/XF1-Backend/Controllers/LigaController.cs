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
        public async Task<IEnumerable<UsuariosLiga>> GetUsuariosLiga(string correo)
        {
            return await _context.UsuariosLigas.FromSqlRaw(LigaRequests.getUsuariosLiga(correo)).ToListAsync();
        }

        // GET api/Liga/CantidadJugador/{correo}
        [HttpGet("CantidadJugador/{correo}")]
        public async Task<CantidadJugador> GetDisponibilidaLigaPrivada(string correo)
        {
            return await _context.CantidadJugadores.FromSqlRaw(LigaRequests.GetDisponibilidaLigaPrivada(correo)).FirstOrDefaultAsync();
        }

        // GET api/Liga/IdPrivadas
        [HttpGet("IdPrivadas")]
        public async Task<IEnumerable<IdPrivadas>> GetIdPrivadas()
        {
            return await _context.IdPrivadas.FromSqlRaw(LigaRequests.GetIdPrivadas).ToListAsync();
        }

        // GET api/Liga/CantidadJugadorPorId/{idLiga}
        [HttpGet("CantidadJugadorPorId/{idLiga}")]
        public async Task<CantidadJugador> GeCantidadLigaPrivada(string idLiga)
        {
            return await _context.CantidadJugadores.FromSqlRaw(LigaRequests.GeCantidadLigaPrivada(idLiga)).FirstOrDefaultAsync();
        }

        // POST api/Liga
        [HttpPost]
        public async Task<ActionResult<Liga>> PostLigaPrivada(NuevaLiga nuevaLiga)
        {
            
            bool permitido;

            // revisión de valores nulos         
            permitido = NullValuesLogicFunctions.ValoresNulosNuevaLiga(nuevaLiga);
            if (permitido == false) return Conflict("Se requieren todos los datos de la nueva liga");

            // revisión de la longitud del nombre de la nueva liga
            permitido = StringLogicFunctions.LongitudNombreNuevaLiga(nuevaLiga.Nombre);
            if (permitido == false) return Conflict("El nombre de la nueva liga debe ser de máximo 30 caracteres alfanuméricos");

            // Tomar llave del campeonato actual
            CampeonatoActual llaveActual = await _context.CampeonatoActual.FromSqlRaw(LigaRequests.GetCampeonatoActual).FirstOrDefaultAsync();

            // Generar la nueva seccion de la llave
            IEnumerable<Liga> ligasPrivadas;
            ligasPrivadas = await _context.Liga.FromSqlRaw(LigaRequests.GetLigasPrivada).ToListAsync();

            string idLigaPrivada = IdLogicFunctions.GenerarLlaveLigaPrivada(llaveActual, ligasPrivadas);

            // Añadir la nueva liga
            await _context.Database.ExecuteSqlInterpolatedAsync(LigaRequests.AnadirNuevaLiga(idLigaPrivada, llaveActual.IdActual, nuevaLiga.Nombre, nuevaLiga.Correo));
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT api/Liga
        [HttpPut]
        public async Task<ActionResult<Liga>> PutLigaPrivada(ActualizarLiga actualizarLiga)
        {
            bool permitido;

            IEnumerable<IdPrivadas> idPrivadas;
            idPrivadas = await _context.IdPrivadas.FromSqlRaw(LigaRequests.GetIdPrivadas).ToListAsync();
            permitido = IdLogicFunctions.RevisarIdLigaPrivada(actualizarLiga, idPrivadas);
            if (permitido == false) return Conflict("La llave insertada no pertenece a ninguna liga privada");

            // revision de que la liga privada existente tenga espacio
            CantidadJugador cantidadJugador = await _context.CantidadJugadores.FromSqlRaw(LigaRequests.GeCantidadLigaPrivada(actualizarLiga.Id)).FirstOrDefaultAsync();
            permitido = IntLogicFunctions.CantidadJugadoresLigaPrivada(cantidadJugador);
            if (permitido == false) return Conflict("La liga privada ya no tiene espacio disponible");

            // añadir el usuario a la liga privada
            await _context.Database.ExecuteSqlInterpolatedAsync(LigaRequests.ActualizarLigaPrivada(actualizarLiga.Id, actualizarLiga.Correo));
            await _context.SaveChangesAsync();

            return Ok();

        }

    }

}
