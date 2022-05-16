using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Models;
using XF1_Backend.Logic;

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
            IEnumerable<Carrera> carreras = await _context.Carrera.FromSqlInterpolated($@"SELECT * FROM CARRERA WHERE IdCampeonato = {carrera.IdCampeonato}").ToListAsync();
            IEnumerable<Fechas> fechas = await _context.FechasCarrera.FromSqlInterpolated($@"SELECT FechaInicio, FechaFin FROM CARRERA WHERE IdCampeonato = {carrera.IdCampeonato}").ToListAsync();
            carrera.Id = LogicFunctions.GenerarId(carreras);
            bool permitido = LogicFunctions.RevisarFechas(carrera.FechaInicio, carrera.FechaFin, fechas);
            if (permitido == false) return Conflict("Existe un conflicto de fechas con otra carrera");

            carrera.Estado = "Pendiente";
            _context.Carrera.Add(carrera);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // GET: api/Carrera
        [HttpGet]
        public async Task<IEnumerable<Carrera>> GetAllCarreras()
        {
            return await _context.Carrera.FromSqlRaw("SELECT * FROM CARRERA").ToListAsync();
        }

        // GET: api/Carrera/Fechas
        [HttpGet("Fechas/{idCampeonato}")]
        public async Task<IEnumerable<Fechas>> GetAllFechas(string idCampeonato)
        {
            return await _context.FechasCarrera.FromSqlInterpolated(@$"SELECT FechaInicio, FechaFin
                                                                    FROM CARRERA
                                                                    WHERE IdCampeonato = {idCampeonato}
                                                                    ORDER BY FechaInicio DESC").ToListAsync();
        }
    }
}
