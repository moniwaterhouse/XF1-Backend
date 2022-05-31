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
            // revision de valores nulos
            /*
             * revisar que el nombre de escuderias y equipos no sea nulo
             * 
             * revisar que sí se consideren todos campos de escuderia y pilotos (que ninguno esté vacío)
             * 
             * 
             */

            // revisión de la extensión de los inputs
            /*
             * Revisar que la extensión del nombre de las escuderías y los equipos sea la que se necesita
             * */

            // revisión de los nombres de las escuderías

            /*
             * revisar que el nombre de una escudería no se repita con los que ya están guardados
             * en la base de datos
             */

            // crear el equipo 1
            IEnumerable<Id> equipoIds = await _context.Ids.FromSqlRaw(EquipoRequests.GetIds).ToListAsync();
            equipo.Id = IdLogicFunctions.GenerarId(equipoIds);

            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
            return Ok(equipo.Id);
        }
    }
}
