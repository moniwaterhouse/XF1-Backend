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
    public class CarreraController : ControllerBase
    {
        private readonly CarreraRepository repo;

        public CarreraController(CarreraDbContext context)
        {
            repo = new CarreraRepository(context);
        }

        // POST:
        [HttpPost]
        public async Task<ActionResult<Carrera>> PostCarrera(Carrera carrera)
        {

            // validaciones carrera
            ObjectResult objectResult = Startup.facade.CarreraValidations(carrera, repo);
            if (objectResult.StatusCode != 200) return objectResult;

            // crear llave
            IEnumerable<Id> carreraIds = repo.GetCarrerasPorCampeontao(carrera);
            carrera.Id = IdLogicFunctions.GenerarId(carreraIds);

            // definir estado por defecto
            carrera.Estado = "Pendiente";

            // añadir la carrera
            await repo.Complete(carrera);

            return Ok();
        }

        // GET: api/Carrera
        [HttpGet]
        public async Task<IEnumerable<Carrera>> GetAllCarreras()
        {
            return await repo.GetAllCarreras();
        }

        // GET: api/Carrera/{idCampeonato}
        [HttpGet("{idCampeonato}")]
        public async Task<IEnumerable<Carrera>> GetAllCarrerasPorCampeontao(string idCampeonato)
        {
            return await repo.GetAllCarrerasPorCampeonato(idCampeonato);
        }

        // GET: api/Carrera/Fechas
        [HttpGet("Fechas/{idCampeonato}")]
        public async Task<IEnumerable<Fechas>> GetAllFechas(string idCampeonato)
        {
            return await repo.GetAllFechas(idCampeonato);
        }

        // GET: api/Carrera/NombreCampeonato
        [HttpGet("NombreCampeonato")]
        public async Task<IEnumerable<CarreraNombre>> GetNombreCampeonato()
        {
            return await repo.GetNombreCampeonato();
        }

    }

}
