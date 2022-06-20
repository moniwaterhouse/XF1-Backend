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
    public class EquipoRepository
    {
        private readonly EquipoDbContext _context;

        public EquipoRepository(EquipoDbContext context)
        {
            _context = context;
        }

        public List<Id> GetAllEquipoId()
        {
            return _context.Ids.FromSqlRaw(EquipoRequests.GetIds).ToList();
        }

        public async Task Complete(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
        }
    }
}
