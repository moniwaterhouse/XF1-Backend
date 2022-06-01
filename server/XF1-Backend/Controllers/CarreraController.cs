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
    public class CarreraController : ControllerBase
    {
        private readonly CarreraDbContext _context;

        public CarreraController(CarreraDbContext context)
        {
            _context = context;
        }

        // POST:
        [HttpPost]
        public async Task<ActionResult<Carrera>> PostCarrera(Carrera carrera)
        {

            bool permitido;

            // revisión de valores nulos         
            permitido = NullValuesLogicFunctions.ValoresNulosCarrera(carrera);
            if (permitido == false) return Conflict("Se requieren todos los datos de la carrera");

            // revisión de la longitud del nombre de la carrera
            permitido = StringLogicFunctions.LongitudNombre(carrera.Nombre);
            if (permitido == false) return Conflict("El nombre de la carrera debe ser de 5 a 30 caracteres");

            // revisión de la longitud del nombre de la pista
            permitido = StringLogicFunctions.LongitudNombre(carrera.NombrePista);
            if (permitido == false) return Conflict("El nombre de la pista debe ser de 5 a 30 caracteres");

            // crear llave
            IEnumerable<Id> carreraIds = await _context.Ids.FromSqlInterpolated(CarreraRequests.getCarreraPorCampeonato(carrera.IdCampeonato)).ToListAsync();
            carrera.Id = IdLogicFunctions.GenerarId(carreraIds);

            // revisión de traslape de fechas
            IEnumerable<Fechas> fechas = await _context.FechasCarrera.FromSqlInterpolated(CarreraRequests.getFechasPorCampeonato(carrera.IdCampeonato)).ToListAsync();
            permitido = DateLogicFunctions.RevisarTraslapeFechas(carrera.FechaInicio, carrera.FechaFin, fechas);
            if (permitido == false) return Conflict("Existe un conflicto de fechas con otra carrera");
           
            // revisión de fechas anteriores a la actual
            permitido = DateLogicFunctions.RevisarFechasAnteriores(carrera.FechaInicio, carrera.FechaFin);
            if (permitido == false) return Conflict("No se puede crear una carrera con una fecha menor a la actual");

            // definir estado por defecto
            carrera.Estado = "Pendiente";

            // añadir la carrera
            _context.Carrera.Add(carrera);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // GET: api/Carrera
        [HttpGet]
        public async Task<IEnumerable<Carrera>> GetAllCarreras()
        {
            return await _context.Carrera.FromSqlRaw(CarreraRequests.getCarreras).ToListAsync();
        }

        // GET: api/Carrera/Fechas
        [HttpGet("Fechas/{idCampeonato}")]
        public async Task<IEnumerable<Fechas>> GetAllFechas(string idCampeonato)
        {
            return await _context.FechasCarrera.FromSqlInterpolated(CarreraRequests.getFechasPorCampeonato(idCampeonato)).ToListAsync();
        }

        // GET: api/Carrera/NombreCampeonato
        [HttpGet("NombreCampeonato")]
        public async Task<IEnumerable<CarreraNombre>> GetNombreCampeonato()
        {
            return await _context.Nombre.FromSqlRaw(CarreraRequests.getCarrerasNombreCampeonato).ToListAsync();
        }

    }

}
