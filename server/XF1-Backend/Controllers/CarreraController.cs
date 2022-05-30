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
            // revisión de valores nulos
            /*
             * Revisión de que ninguno de los datos sea nulo
             * 
             */

            // revisión de longitud
            /*
             * Revisión de que el nombre de carrera y pista cumplan con ser menores de 30 caracteres
             */

            // crear llave
            IEnumerable<Id> carreraIds = await _context.Ids.FromSqlInterpolated(CarreraRequests.getCarreraPorCampeonato(carrera.IdCampeonato)).ToListAsync();
            carrera.Id = IdLogicFunctions.GenerarId(carreraIds);

            // verificar fechas
            IEnumerable<Fechas> fechas = await _context.FechasCarrera.FromSqlInterpolated(CarreraRequests.getFechasPorCampeonato(carrera.IdCampeonato)).ToListAsync();
            bool permitido = DateLogicFunctions.RevisarFechas(carrera.FechaInicio, carrera.FechaFin, fechas);
            if (permitido == false) return Conflict("Existe un conflicto de fechas con otra carrera");

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
