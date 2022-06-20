using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Models;
using XF1_Backend.Logic;
using XF1_Backend.Requests;

namespace XF1_Backend.Repositories
{
    public class LigaRepository
    {
        private readonly LigaDbContext _context;

        public LigaRepository(LigaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PuntajesPublica>> GetPuntajesPublica()
        {
            return await _context.PuntajesPublicas.FromSqlRaw(LigaRequests.getPuntajesPublica).ToListAsync();
        }

        public async Task<IEnumerable<PuntajesPublica>> GetPuntajesPublica(string correo)
        {
            return await _context.PuntajesPublicas.FromSqlRaw(LigaRequests.getPuntajePublicaPorUsuario(correo)).ToListAsync();
        }

        public async Task<IEnumerable<PuntajesPublica>> GetPuntajesPrivada(string correo)
        {
            return await _context.PuntajesPublicas.FromSqlRaw(LigaRequests.getPuntajePrivadaPorUsuario(correo)).ToListAsync();
        }

        public async Task<InfoLigaPrivada> GetInfoLigaPrivada(string correo)
        {
            return await _context.InfoLigaPrivadas.FromSqlRaw(LigaRequests.getInfoLigaPrivada(correo)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UsuariosLiga>> GetUsuariosLiga(string correo)
        {
            return await _context.UsuariosLigas.FromSqlRaw(LigaRequests.getUsuariosLiga(correo)).ToListAsync();
        }

        public async Task<CantidadJugador> GetDisponibilidaLigaPrivada(string correo)
        {
            return await _context.CantidadJugadores.FromSqlRaw(LigaRequests.GetDisponibilidaLigaPrivada(correo)).FirstOrDefaultAsync();
        }

        public List<IdPrivadas> GetIdPrivadas()
        {
            return _context.IdPrivadas.FromSqlRaw(LigaRequests.GetIdPrivadas).ToList();
        }

        public CantidadJugador GeCantidadLigaPrivada(string idLiga)
        {
            return _context.CantidadJugadores.FromSqlRaw(LigaRequests.GeCantidadLigaPrivada("\'" + idLiga + "\'")).FirstOrDefault();
        }

        public CampeonatoActual GetLlaveCampeonatoActual()
        {
            return _context.CampeonatoActual.FromSqlRaw(LigaRequests.GetCampeonatoActual).FirstOrDefault();
        }

        public List<Liga> GetLigasPrivada()
        {
            return _context.Liga.FromSqlRaw(LigaRequests.GetLigasPrivada).ToList();
        }

        public async Task AnadirNuevaLiga(string idLigaPrivada, CampeonatoActual llaveActual, NuevaLiga nuevaLiga)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(LigaRequests.AnadirNuevaLiga(idLigaPrivada, llaveActual.IdActual, nuevaLiga.Nombre, nuevaLiga.Correo));
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarLigaPrivada(ActualizarLiga actualizarLiga)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(LigaRequests.ActualizarLigaPrivada(actualizarLiga.Id, actualizarLiga.Correo));
            await _context.SaveChangesAsync();
        }
    }
}
