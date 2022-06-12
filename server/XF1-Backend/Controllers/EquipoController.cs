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

            bool permitido;

            // revisión de valores nulos         
            permitido = NullValuesLogicFunctions.ValoresNulosEquipo(equipo);
            if (permitido == false) return Conflict("Se requieren todos los datos del equipo");

            // revisión de la longitud del nombre de la escudería
            permitido = StringLogicFunctions.LongitudMarcaEscuderia(equipo.MarcaEscuderia);
            if (permitido == false) return Conflict("El nombre de la escudería debe ser de máximo 30 caracteres alfanuméricos");

            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
            return Ok(equipo.Id);

        }

    }

}
