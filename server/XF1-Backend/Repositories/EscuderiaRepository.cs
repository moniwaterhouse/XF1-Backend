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
    public class EscuderiaRepository
    {
        private readonly EscuderiaDbContext _context;

        public EscuderiaRepository(EscuderiaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Escuderia>> GetEscuderias()
        {
            return await _context.Escuderia.FromSqlRaw(EscuderiaRequests.GetEscuderias).ToListAsync();
        }
    }
}
