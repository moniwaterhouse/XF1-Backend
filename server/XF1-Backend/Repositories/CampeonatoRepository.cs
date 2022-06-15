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
    public class CampeonatoRepository
    {
        private readonly CampeonatoDbContext _context;

        public CampeonatoRepository(CampeonatoDbContext context)
        {
            _context = context;
        }

        public List<Campeonato> GetAllCampeonatos()
        {
            return _context.Campeonato.FromSqlRaw(CampeonatoRequests.getCampeonatos).ToList();
        }

        public List<Fechas> GetAllFechasCampeonatos()
        {
            return _context.Fechas.FromSqlRaw(CampeonatoRequests.getFechasCampeonatos).ToList();
        }

        public async Task Complete(Campeonato campeonato)
        {
            _context.Campeonato.AddAsync(campeonato);
            await _context.SaveChangesAsync();
        }

        public async Task PostLigaPublica(Campeonato campeonato)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(CampeonatoRequests.crearLiga(campeonato.Id, 0));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Fechas>> GetFechas()
        {
            return await _context.Fechas.FromSqlRaw(CampeonatoRequests.getFechas).ToListAsync();
        }

        public async Task<IEnumerable<Nombres>> GetNombres()
        {
            return await _context.Nombres.FromSqlRaw(CampeonatoRequests.getNombres).ToListAsync();
        }

        public async Task<CampeonatoPresupuesto> GetPresupuesto()
        {
            return await _context.CampeonatoPresupuesto.FromSqlRaw(CampeonatoRequests.getPresupuestoActual).FirstOrDefaultAsync();
        }
    }
}
