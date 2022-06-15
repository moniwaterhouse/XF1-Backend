using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Models;
using XF1_Backend.Logic;
using XF1_Backend.Requests;
using XF1_Backend.Repositories;

namespace XF1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly EquipoRepository repo;

        public EquipoController(EquipoDbContext context)
        {
            repo = new EquipoRepository(context);
        }

        // POST api/Equipo
        [HttpPost]
        public async Task<ActionResult<Equipo>> PostEquipo(Equipo equipo)
        {
            // crear el id del equipo
            try
            {
                IEnumerable<Id> equipoIds = repo.GetAllEquipoId();
                equipo.Id = IdLogicFunctions.GenerarId(equipoIds);

                ObjectResult objectResult = Startup.facade.EquipoValidations(equipo);
                if (objectResult.StatusCode != 200) return objectResult;
                /*
                // revisión de valores nulos         
                permitido = NullValuesLogicFunctions.ValoresNulosEquipo(equipo);
                if (permitido == false) return Conflict("Se requieren todos los datos del equipo");

                // revisión de la longitud del nombre de la escudería
                permitido = StringLogicFunctions.LongitudMarcaEscuderia(equipo.MarcaEscuderia);
                if (permitido == false) return Conflict("El nombre de la escudería debe ser de máximo 30 caracteres alfanuméricos");
                */

                await repo.Complete(equipo);

                return Ok(equipo.Id);

            }
            catch
            {
                return StatusCode(400, "Bad request");
            }

        }

    }

}
