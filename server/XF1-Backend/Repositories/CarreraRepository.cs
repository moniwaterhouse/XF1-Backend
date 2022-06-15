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
    public class CarreraRepository
    {
        private readonly CarreraDbContext _context;

        public CarreraRepository(CarreraDbContext context)
        {
            _context = context;
        }

        public List<Id> GetCarrerasPorCampeontao(Carrera carrera)
        {
            return _context.Ids.FromSqlInterpolated(CarreraRequests.getCarreraPorCampeonato(carrera.IdCampeonato)).ToList();
        }

        public List<Fechas> GetFechasCarreraPorCampeonato(Carrera carrera)
        {
            return _context.FechasCarrera.FromSqlInterpolated(CarreraRequests.getFechasPorCampeonato(carrera.IdCampeonato)).ToList();
        }

        public async Task Complete(Carrera carrera)
        {
            _context.Carrera.Add(carrera);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Carrera>> GetAllCarreras()
        {
            return await _context.Carrera.FromSqlRaw(CarreraRequests.getCarreras).ToListAsync();
        }

        public async Task<IEnumerable<Carrera>> GetAllCarrerasPorCampeonato(string idCampeonato)
        {
            return await _context.Carrera.FromSqlRaw(CarreraRequests.getAllCarrerasPorCampeonato("\'"+idCampeonato+"\'")).ToListAsync();
        }

        public async Task<IEnumerable<Fechas>> GetAllFechas(string idCampeonato)
        {
            return await _context.FechasCarrera.FromSqlInterpolated(CarreraRequests.getFechasPorCampeonato(idCampeonato)).ToListAsync();
        }

        public async Task<IEnumerable<CarreraNombre>> GetNombreCampeonato()
        {
            return await _context.Nombre.FromSqlRaw(CarreraRequests.getCarrerasNombreCampeonato).ToListAsync();
        }

    }
}
