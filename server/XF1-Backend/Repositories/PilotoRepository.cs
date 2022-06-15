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
    public class PilotoRepository
    {
        private readonly PilotoDbContext _context;

        public PilotoRepository(PilotoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Piloto>> GetPilotos()
        {
            return await _context.Pilotos.FromSqlRaw(PilotoRequests.GetPilotos).ToListAsync();
        }
    }
}
