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
    public class EquipoService : ControllerBase
    {

        public ObjectResult NullValidations(Equipo equipo)
        {
            bool permitido = NullValuesLogicFunctions.ValoresNulosEquipo(equipo);
            if (permitido == false) return StatusCode(409, "Se requieren todos los datos del equipo");

            return StatusCode(200, "Ok");
        }

        public ObjectResult StringValidations(Equipo equipo)
        {
            bool permitido = StringLogicFunctions.LongitudMarcaEscuderia(equipo.MarcaEscuderia);
            if (permitido == false) return StatusCode(409, "El nombre de la escudería debe ser de máximo 30 caracteres alfanuméricos");

            return StatusCode(200, "Ok");
        }

    }
}
