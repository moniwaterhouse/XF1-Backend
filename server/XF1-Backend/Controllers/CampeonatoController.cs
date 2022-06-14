using Microsoft.AspNetCore.Http;
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
using XF1_Backend.Services;

namespace XF1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        //private readonly CampeonatoDbContext _context;
        private readonly CampeonatoRepository repo;

        public CampeonatoController(CampeonatoDbContext context)
        {
            //_context = context;
            repo = new CampeonatoRepository(context);

        }

        // POST: api/Campeonato
        [HttpPost]
        public async Task<ActionResult<Campeonato>> PostCampeonatos(Campeonato campeonato)
        {

            bool permitido;

            ActionResult actionResult = Startup.facade.CampeonatoValidations(campeonato);
            if (actionResult != Ok()) return actionResult;

            /*
            // revisión de valores nulos           
            permitido = NullValuesLogicFunctions.ValoresNulosCampeonato(campeonato);
            if (permitido == false) return Conflict("Se requieren todos los datos del campeonato");
            

            // revisión de la longitud del nombre del campeonato
            permitido = StringLogicFunctions.LongitudNombre(campeonato.Nombre);
            if (permitido == false) return Conflict("El nombre del campeonato debe ser de 5 a 30 caracteres");

            // revisión de la longitud de la descripción del campeonato
            permitido = StringLogicFunctions.LongitudDescripcionCampeonato(campeonato.ReglasPuntuacion);
            if (permitido == false) return Conflict("La descripción del campeonato debe ser de máximo 1000 caracteres");

            // generar llave unica del campeonato
            IEnumerable<Campeonato> campeonatosAnteriores = repo.GetAllCampeonatos();
            campeonato.Id = IdLogicFunctions.GenerarLlaveCampeonato(campeonatosAnteriores);

            // revisión de traslape de fechas
            IEnumerable<Fechas> fechas = repo.GetAllFechasCampeonatos();
            permitido = DateLogicFunctions.RevisarTraslapeFechas(campeonato.FechaInicio, campeonato.FechaFin, fechas);
            if (permitido == false) return Conflict("Existe un conflicto de fechas con otro campeonato");

            // revisión de fechas anteriores a la actual
            permitido = DateLogicFunctions.RevisarFechasAnteriores(campeonato.FechaInicio, campeonato.FechaFin);
            if (permitido == false) return Conflict("No se puede crear un campeonato con una fecha menor a la actual");
            */
            // añadir campeonato
            repo.Complete(campeonato);

            // crear liga publica y añadir los jugadoers ahí
            repo.PostLigaPublica(campeonato);

            return Ok();

        }

        // GET api/Campeonato
        [HttpGet]
        public async Task<IEnumerable<Campeonato>> GetCampeonatos()
        {
            return repo.GetAllCampeonatos();
        }

        // GET api/Campeonato/Fechas
        [HttpGet("Fechas")]
        public async Task<IEnumerable<Fechas>> GetFechas()
        {
            return await repo.GetFechas();
        }

        // GET api/Campeonato/Nombres
        [HttpGet("Nombres")]
        public async Task<IEnumerable<Nombres>> GetNombres()
        {
            return await repo.GetNombres();
        }

        // GET api/Campeonato/Presupuesto
        [HttpGet("Presupuesto")]
        public async Task<CampeonatoPresupuesto> GetPresupuesto()
        {
            return await repo.GetPresupuesto();
        }

    }

}
