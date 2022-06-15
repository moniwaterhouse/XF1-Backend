using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using XF1_Backend.Logic;
using XF1_Backend.Models;
using XF1_Backend.Repositories;

namespace XF1_Backend.Services
{
    public class CampeonatoService : ControllerBase
    {

        public ObjectResult NullValidations(Campeonato campeonato)
        {
            bool permitido = NullValuesLogicFunctions.ValoresNulosCampeonato(campeonato);
            if (permitido == false) return StatusCode(409, "Verifique que no haya valores nulos");
            
            return StatusCode(200, "ok");
        }

        public ObjectResult StringValidations(Campeonato campeonato)
        {
            bool permitido = StringLogicFunctions.LongitudNombre(campeonato.Nombre);
            if (permitido == false) return StatusCode(409, "El nombre del campeonato debe tener entre 5 y 30 caracteres.");

            permitido = StringLogicFunctions.LongitudDescripcionCampeonato(campeonato.ReglasPuntuacion);
            if (permitido == false) return StatusCode(409, "La longitud de la descipción debe ser menor a 1000 caracteres.");

            return StatusCode(200, "Ok");

        }

        public ObjectResult FehcasValidations(Campeonato campeonato, CampeonatoRepository repo)
        {
            IEnumerable<Fechas> fechas = repo.GetAllFechasCampeonatos();
            bool permitido = DateLogicFunctions.RevisarTraslapeFechas(campeonato.FechaInicio, campeonato.FechaFin, fechas);
            if (permitido == false) return StatusCode(409, "Las fechas de un campeonato no pueden coincidir con las de otro.");

            // revisión de fechas anteriores a la actual
            permitido = DateLogicFunctions.RevisarFechasAnteriores(campeonato.FechaInicio, campeonato.FechaFin);
            if (permitido == false) return StatusCode(409, "No se puede crear un campeonato con fechas menores a la actual.");

            return StatusCode(200, "Ok");
        }


    }
}
