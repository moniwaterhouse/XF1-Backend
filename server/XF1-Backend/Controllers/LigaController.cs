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
    public class LigaController : ControllerBase
    {
        private readonly LigaRepository repo;

        public LigaController(LigaDbContext context)
        {
            repo = new LigaRepository(context);
        }

        // GET api/Liga/PuntajesPublica
        [HttpGet("PuntajesPublica")]
        public async Task<IEnumerable<PuntajesPublica>> GetPuntajesPublica()
        {
            return await repo.GetPuntajesPublica();
        }

        // GET api/Liga/PuntajesPublica/{Correo}
        [HttpGet("PuntajesPublica/{correo}")]
        public async Task<IEnumerable<PuntajesPublica>> GetPuntajesPublica(string correo)
        {
            return await repo.GetPuntajesPublica(correo);
        }

        // GET api/Liga/PuntajesPrivada/{Correo}
        [HttpGet("PuntajesPrivada/{correo}")]
        public async Task<IEnumerable<PuntajesPublica>> GetPuntajesPrivada(string correo)
        {
            return await repo.GetPuntajesPrivada(correo);
        }

        // GET api/Liga/InfoPrivada
        [HttpGet("InfoPrivada/{correo}")]
        public async Task<InfoLigaPrivada> GetInfoLigaPrivada(string correo)
        {
            return await repo.GetInfoLigaPrivada(correo);
        }

        // GET api/Liga/UsuariosLiga
        [HttpGet("UsuariosLiga/{correo}")]
        public async Task<IEnumerable<UsuariosLiga>> GetUsuariosLiga(string correo)
        {
            return await repo.GetUsuariosLiga(correo);
        }

        // GET api/Liga/CantidadJugador/{correo}
        [HttpGet("CantidadJugador/{correo}")]
        public async Task<CantidadJugador> GetDisponibilidaLigaPrivada(string correo)
        {
            return await repo.GetDisponibilidaLigaPrivada(correo);
        }

        // GET api/Liga/IdPrivadas
        [HttpGet("IdPrivadas")]
        public IEnumerable<IdPrivadas> GetIdPrivadas()
        {
            return repo.GetIdPrivadas();
        }

        // GET api/Liga/CantidadJugadorPorId/{idLiga}
        [HttpGet("CantidadJugadorPorId/{idLiga}")]
        public CantidadJugador GeCantidadLigaPrivada(string idLiga)
        {
            return repo.GeCantidadLigaPrivada(idLiga);
        }

        // POST api/Liga
        [HttpPost]
        public async Task<ActionResult<Liga>> PostLigaPrivada(NuevaLiga nuevaLiga)
        {
            try
            {
                // validaciones añadir una liga
                ObjectResult objectResult = Startup.facade.CrearLigaValidations(nuevaLiga);
                if (objectResult.StatusCode != 200) return objectResult;

                // Tomar llave del campeonato actual
                CampeonatoActual llaveActual = repo.GetLlaveCampeonatoActual();

                // Generar la nueva seccion de la llave
                IEnumerable<Liga> ligasPrivadas = repo.GetLigasPrivada();
                string idLigaPrivada = IdLogicFunctions.GenerarLlaveLigaPrivada(llaveActual, ligasPrivadas);

                // Añadir la nueva liga
                await repo.AnadirNuevaLiga(idLigaPrivada, llaveActual, nuevaLiga);

                return Ok();
            }
            catch
            {
                return StatusCode(400, "Bad request");
            }
        }

        // PUT api/Liga
        [HttpPut]
        public async Task<ActionResult<Liga>> PutLigaPrivada(ActualizarLiga actualizarLiga)
        {
            try
            {
                // validaciones actualizar liga
                ObjectResult objectResult = Startup.facade.ActualizarLigaValidations(actualizarLiga, repo);
                if (objectResult.StatusCode != 200) return objectResult;

                // añadir el usuario a la liga privada
                await repo.ActualizarLigaPrivada(actualizarLiga);

                return Ok();
            }
            catch
            {
                return StatusCode(400, "Bad request actualizar");
            }
        }

        


    }

}
