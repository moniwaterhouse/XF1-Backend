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
    public class PuntajeController : ControllerBase
    {
        private readonly PuntajeRepository repo;

        public PuntajeController(PuntajeDBContext context)
        {
            repo = new PuntajeRepository(context);
        }

        
        // api/Puntaje - metodo para actualizar puntajes y precios
        [HttpPost]
        public async Task<ActionResult<Puntaje>> PostPuntajes(IEnumerable<Puntaje> puntajes)
        {
            // metodo encargado de la actualizacion
            ObjectResult objectResult;
            objectResult = await Startup.facade.ActualizarPuntajesPrecios(puntajes, repo);
            if (objectResult.StatusCode != 200) return objectResult;

            return Ok();
        }
        
    }
}
