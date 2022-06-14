using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Logic;
using XF1_Backend.Models;

namespace XF1_Backend.Services
{
    public class ServiceFacade : ControllerBase
    {
        protected CampeonatoService _campeonatoService;

        public ServiceFacade(CampeonatoService campeonatoService)
        {
            this._campeonatoService = campeonatoService;
        }

        public ActionResult CampeonatoValidations(Campeonato campeonato)
        {
            ActionResult actionResult;
            actionResult = _campeonatoService.CampeonatoValidations(campeonato);
            if (actionResult != Ok()) return actionResult;

            else return Ok();
        }


    }
}
