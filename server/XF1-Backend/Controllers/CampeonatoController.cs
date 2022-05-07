using Microsoft.AspNetCore.Http;
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
    public class CampeonatoController : ControllerBase
    {
        private readonly CampeonatoDbContext _context;

        public CampeonatoController(CampeonatoDbContext context)
        {
            _context = context;
        }

        private static string GenerarLlave()
        {
            Random rd = new Random();
            string possibleCharacters = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";

            string key = "";
            int rand_num;

            for (int i = 0; i < 6; i++)
            {
                rand_num = rd.Next(0, 35);
                key += possibleCharacters[rand_num];
            }

            return key;
        }

        private static bool RevisarFechas(DateTime fechaInicio, DateTime fechaFinal, IEnumerable<Fechas> fechas)
        { 

            foreach (var fecha in fechas)
            {
                if (DateTime.Compare(fechaInicio, fecha.FechaInicio) >= 0 &&
                    DateTime.Compare(fechaInicio, fecha.FechaFin) <= 0) return false;

                if (DateTime.Compare(fechaFinal, fecha.FechaInicio) >= 0 &&
                    DateTime.Compare(fechaFinal, fecha.FechaFin) <= 0) return false;

                if (DateTime.Compare(fechaInicio, fecha.FechaInicio) <= 0 &&
                    DateTime.Compare(fechaFinal, fecha.FechaFin) >= 0) return false;
            }

            return true;
        }

        // POST: api/Campeonato
        [HttpPost]
        public async Task<ActionResult<Campeonato>> PostCampeonatos(Campeonato campeonato)
        {

            // validacion para que no haya valores nulos
            if (campeonato.Nombre != null &&
                campeonato.FechaInicio != null &&
                campeonato.HoraInicio != null &&
                campeonato.FechaFin != null &&
                campeonato.HoraFin != null)
            {
                int nameLenght = campeonato.Nombre.Length;
                int descriptionLength = campeonato.ReglasPuntuacion.Length;

                if (nameLenght < 5 || nameLenght > 30)
                    return Conflict("El nombre del campeonato debe estar entre 5 y 30 caracteres");

                // validacion de la extension de la descripcion
                else if (descriptionLength > 1000)
                    return Conflict("La descripción no puede exceder los 1000 caracteres.");

                // generar llave unica del campeonato
                campeonato.Id = GenerarLlave();

                // revision de choque de fechas
                IEnumerable<Fechas> fechas;
                fechas = await _context.Fechas.FromSqlRaw("SELECT * FROM CAMPEONATO").ToListAsync();
                bool permitido = RevisarFechas(campeonato.FechaInicio, campeonato.FechaFin, fechas);
                if (permitido == false) return Conflict("Existe un conflicto de fechas con otro campeonato");

                // añadir campeonato
                _context.Campeonato.Add(campeonato);
                await _context.SaveChangesAsync();

                // crear liga publica y añadir los jugadoers ahí
                await _context.Database.ExecuteSqlInterpolatedAsync($@"EXECUTE sp_crear_liga {campeonato.Id}");
                await _context.SaveChangesAsync();

                return Ok();
            }

            // validacion de la extension del nombre
            else return Conflict("No se pudo agregar campeonato, hay valores nulos en campos requeridos.");            


        }

        // GET api/Campeonato
        [HttpGet]
        public async Task<IEnumerable<Campeonato>> GetCampeonatos()
        {
            return await _context.Campeonato.FromSqlRaw("SELECT * FROM Campeonato").ToListAsync();
        }


    }
}
