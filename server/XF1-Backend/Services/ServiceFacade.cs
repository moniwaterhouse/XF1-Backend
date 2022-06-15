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
using XF1_Backend.Repositories;

namespace XF1_Backend.Services
{
    public class ServiceFacade : ControllerBase
    {
        protected CampeonatoService _campeonatoService;

        public ServiceFacade(CampeonatoService campeonatoService)
        {
            this._campeonatoService = campeonatoService;
        }

        public ObjectResult CampeonatoValidations(Campeonato campeonato, CampeonatoRepository repo)
        {
            try
            {
                ObjectResult objectResult;
                objectResult = _campeonatoService.NullValidations(campeonato);
                if (objectResult.StatusCode != 200) return objectResult;

                objectResult = _campeonatoService.StringValidations(campeonato);
                if (objectResult.StatusCode != 200) return objectResult;

                objectResult = _campeonatoService.FehcasValidations(campeonato, repo);
                if (objectResult.StatusCode != 200) return objectResult;
                
                return StatusCode(200, "Ok");
            }
            catch
            {
                return StatusCode(400, "Bad request");
            }

        }


    }
}
