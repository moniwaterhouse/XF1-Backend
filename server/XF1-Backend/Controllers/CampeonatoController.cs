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
            // validaciones campeonato
            ObjectResult actionResult = Startup.facade.CampeonatoValidations(campeonato, repo);
            if (actionResult.StatusCode != 200) return actionResult;

            // generar llave unica del campeonato
            IEnumerable<Campeonato> campeonatosAnteriores = repo.GetAllCampeonatos();
            campeonato.Id = IdLogicFunctions.GenerarLlaveCampeonato(campeonatosAnteriores);
          
            // añadir campeonato
            await repo.Complete(campeonato);

            // crear liga publica y añadir los jugadoers ahí
            await repo.PostLigaPublica(campeonato);

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
