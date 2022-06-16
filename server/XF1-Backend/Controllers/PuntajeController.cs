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
            foreach (var puntaje in puntajes)
            {
                if(puntaje.Tipo == "Piloto")
                {
                    await repo.UpdatePrecioPiloto(puntaje.Nombre, puntaje.Precio);

                    // definir puntaje a piloto
                    int puntos = (17 - puntaje.PosicionCarrera) + (17 - puntaje.PosicionCalificacion);
                    puntaje.nuevosPuntos = puntos;

                    // deifinir puntaje a escuderia
                    foreach (var puntaje_ in puntajes)
                    {
                        if(puntaje_.Tipo == "Constructor")
                        {
                            if (puntaje_.Constructor == puntaje.Constructor)
                            {
                                puntaje_.nuevosPuntos += puntos;
                            }
                        }
                    }
                }
                
                if(puntaje.Tipo == "Constructor")
                {
                    await repo.UpdatePrecioEscuderia(puntaje.Nombre, puntaje.Precio);
                }

            }

            foreach (var puntaje in puntajes)
            {
                await repo.UpdatePuntajes(puntaje.nuevosPuntos, puntaje.Nombre, puntaje.Tipo);
            }

            return Ok();
        }
        
    }
}
