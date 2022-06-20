using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using XF1_Backend.Logic;
using XF1_Backend.Models;
using XF1_Backend.Repositories;

namespace XF1_Backend.Services
{
    public class PuntajeService : ControllerBase
    {
        public async Task<ObjectResult> UpdatePrecios(IEnumerable<Puntaje> puntajes, PuntajeRepository repo)
        {
            try
            {
                // update precios

                foreach (var puntaje in puntajes)
                {
                    if (puntaje.Tipo == "Piloto")
                    {
                        await repo.UpdatePrecioPiloto(puntaje.Nombre, puntaje.Precio);

                        // definir puntaje a piloto
                        int puntos = (17 - puntaje.PosicionCarrera) + (17 - puntaje.PosicionCalificacion);
                        puntaje.nuevosPuntos = puntos;

                        // deifinir puntaje a escuderia
                        foreach (var puntaje_ in puntajes)
                        {
                            System.Console.WriteLine(puntaje.Constructor_NaN);
                            System.Console.WriteLine(puntaje_.Constructor_NaN);
                            if (puntaje_.Tipo == "Constructor")
                            {
                                if (puntaje_.Constructor_NaN == puntaje.Constructor_NaN)
                                {
                                    puntaje_.nuevosPuntos += puntos;
                                }
                            }
                        }
                    }

                    if (puntaje.Tipo == "Constructor")
                    {
                        await repo.UpdatePrecioEscuderia(puntaje.Nombre, puntaje.Precio);
                    }

                }

                return StatusCode(200, "Ok");
            }
            catch
            {
                return StatusCode(400, "Bad request");
            }
        }

        public async Task<ObjectResult> UpdatePuntajes(IEnumerable<Puntaje> puntajes, PuntajeRepository repo)
        {
            try
            {
                // por cada piloto o escuderia se actualiza el puntaje de los equipos
                foreach (var puntaje in puntajes)
                {

                    await repo.UpdatePuntajes(puntaje.nuevosPuntos, puntaje.Nombre, puntaje.Tipo);
                }

                return StatusCode(200, "Ok");
            }
            catch
            {
                return StatusCode(400, "Bad request");
            }
        }

        public ObjectResult UpdateEstadoCarrera(PuntajeRepository repo)
        {
            try
            {
                repo.UpdateEstadoCarrera();
                return StatusCode(200, "Ok");
            }
            catch
            {
                return StatusCode(400, "Bad request");
            }
        }


    }
}
