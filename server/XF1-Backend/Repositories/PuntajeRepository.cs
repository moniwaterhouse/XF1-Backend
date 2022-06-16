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
    }
}
