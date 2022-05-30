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
    public class EquipoController : ControllerBase
    {
        private readonly EquipoDbContext _context;

        public EquipoController(EquipoDbContext context)
        {
            _context = context;
        }

        // POST api/Equipo
        [HttpPost]
        public async Task<ActionResult<Equipo>> PostEquipo(Equipo equipo)
        {
            // crear el equipo 1
            IEnumerable<Id> equipoIds = await _context.Ids.FromSqlRaw(EquipoRequests.GetIds).ToListAsync();
            equipo.Id = IdLogicFunctions.GenerarId(equipoIds);

            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
            return Ok(equipo.Id);
        }
    }
}
