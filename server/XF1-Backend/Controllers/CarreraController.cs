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
            // crear llave
            IEnumerable<Carrera> carreras = await _context.Carrera.FromSqlInterpolated(CarreraRequests.getCarreraPorCampeonato(carrera.IdCampeonato)).ToListAsync();
            carrera.Id = LogicFunctions.GenerarId(carreras);

            // verificar fechas
            IEnumerable<Fechas> fechas = await _context.FechasCarrera.FromSqlInterpolated(CarreraRequests.getFechasPorCampeonato(carrera.IdCampeonato)).ToListAsync();
            bool permitido = LogicFunctions.RevisarFechas(carrera.FechaInicio, carrera.FechaFin, fechas);
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
