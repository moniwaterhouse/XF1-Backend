using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using XF1_Backend.Logic;
using XF1_Backend.Models;

namespace XF1_Backend.Services
{
    public class CampeonatoService : ControllerBase
    {

        public ActionResult CampeonatoValidations(Campeonato campeonato)
        {
            bool permitido = NullValuesLogicFunctions.ValoresNulosCampeonato(campeonato);
            if (permitido == false) return Conflict("Se requieren todos los datos del campeonato");
            else return Ok();
        }
    }
}
