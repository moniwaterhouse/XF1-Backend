using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Models;
using XF1_Backend.Logic;
using XF1_Backend.Requests;
using Microsoft.AspNetCore.Mvc;
using XF1_Backend.Repositories;

namespace XF1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscuderiaController : ControllerBase
    {
        private readonly EscuderiaRepository repo;

        public EscuderiaController(EscuderiaDbContext context)
        {
            repo = new EscuderiaRepository(context);
        }

        // GET api/Escuderia
        [HttpGet]
        public async Task<IEnumerable<Escuderia>> GetEscuderias()
        {
            return await repo.GetEscuderias();
        }

    }
}
