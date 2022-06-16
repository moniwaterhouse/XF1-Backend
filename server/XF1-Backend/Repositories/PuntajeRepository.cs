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
    public class PuntajeRepository
    {
        private readonly PuntajeDBContext _context;

        public PuntajeRepository(PuntajeDBContext context)
        {
            _context = context;
        }

        // actualizar precio piloto
        public async Task UpdatePrecioPiloto(string piloto, int precio)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(PuntajeRequests.UpdatePrecioPiloto(piloto,precio));
        }

        // actualizar precio escuderia
        public async Task UpdatePrecioEscuderia(string escuderia, int precio)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(PuntajeRequests.UpdatePrecioEscuderia(escuderia, precio));
        }

        // actualizar los puntos
        public async Task UpdatePuntajes(int nuevosPuntos, string nombre, string tipo)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(PuntajeRequests.UpdatePuntajes(nuevosPuntos, nombre, tipo));
        }

        // actualizr estado carrera
        public void UpdateEstadoCarrera()
        {
            _context.Database.ExecuteSqlInterpolated(PuntajeRequests.UpdateEstadoCarrera);
        }
    }
}
