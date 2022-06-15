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
    public class CarreraService : ControllerBase
    {
        public ObjectResult NullValidations(Carrera carrera)
        {
            bool permitido = NullValuesLogicFunctions.ValoresNulosCarrera(carrera);
            if (permitido == false) return StatusCode(409, "Verifique que no haya valores nulos");

            return StatusCode(200, "Ok");
        }

        public ObjectResult StringValidations(Carrera carrera)
        {
            // revisión de la longitud del nombre de la carrera
            bool permitido = StringLogicFunctions.LongitudNombre(carrera.Nombre);
            if (permitido == false) return StatusCode(409, "El nombre de la carrera debe ser de 5 a 30 caracteres");

            // revisión de la longitud del nombre de la pista
            permitido = StringLogicFunctions.LongitudNombre(carrera.NombrePista);
            if (permitido == false) return StatusCode(409, "El nombre de la pista debe ser de 5 a 30 caracteres");

            return StatusCode(200, "Ok");
        }

        public ObjectResult FechasValidations(Carrera carrera, CarreraRepository repo)
        {
            // revisión de traslape de fechas
            IEnumerable<Fechas> fechas = repo.GetFechasCarreraPorCampeonato(carrera);
            bool permitido = DateLogicFunctions.RevisarTraslapeFechas(carrera.FechaInicio, carrera.FechaFin, fechas);
            if (permitido == false) return StatusCode(409, "Existe un conflicto de fechas con otra carrera");

            // revisión de fechas anteriores a la actual
            permitido = DateLogicFunctions.RevisarFechasAnteriores(carrera.FechaInicio, carrera.FechaFin);
            if (permitido == false) return StatusCode(409, "No se puede crear una carrera con una fecha menor a la actual");

            return StatusCode(200, "Ok");
        }


        
    }
}
