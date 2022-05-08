using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Models;

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

        private static int GenerarId(IEnumerable<Carrera> carreras)
        {   
            int newId = 1;

            foreach (var carrera in carreras)
            {
                if (carrera.Id >= newId) newId = carrera.Id + 1;
            }

            return newId;

        }

        private static bool RevisarFechas(DateTime fechaInicio, DateTime fechaFinal, IEnumerable<Carrera> carreras)
        {

            foreach (var carrera in carreras)
            {
                if (DateTime.Compare(fechaInicio, carrera.FechaInicio) >= 0 &&
                    DateTime.Compare(fechaInicio, carrera.FechaFin) <= 0) return false;

                if (DateTime.Compare(fechaFinal, carrera.FechaInicio) >= 0 &&
                    DateTime.Compare(fechaFinal, carrera.FechaFin) <= 0) return false;

                if (DateTime.Compare(fechaInicio, carrera.FechaInicio) <= 0 &&
                    DateTime.Compare(fechaFinal, carrera.FechaFin) >= 0) return false;
            }

            return true;
        }

        // POST:
        [HttpPost]
        public async Task<ActionResult<Carrera>> PostCarrera(Carrera carrera)
        {
            IEnumerable<Carrera> carreras = await _context.Carrera.FromSqlInterpolated($@"SELECT * FROM CARRERA WHERE IdCampeonato = {carrera.IdCampeonato}").ToListAsync();
            carrera.Id = GenerarId(carreras);
            bool permitido = RevisarFechas(carrera.FechaInicio, carrera.FechaFin, carreras);
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
        public async Task<IEnumerable<FechasCarrera>> GetAllFechas(string idCampeonato)
        {
            return await _context.FechasCarrera.FromSqlInterpolated(@$"SELECT FechaInicio, FechaFin
                                                                    FROM CARRERA
                                                                    WHERE IdCampeonato = {idCampeonato}
                                                                    ORDER BY FechaInicio DESC").ToListAsync();
        }
    }
}
