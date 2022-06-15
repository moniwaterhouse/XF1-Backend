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
    public class PilotoController : ControllerBase
    {
        private readonly PilotoRepository repo;

        public PilotoController(PilotoDbContext context)
        {
            repo = new PilotoRepository(context);
        }

        // GET api/Piloto
        [HttpGet]
        public async Task<IEnumerable<Piloto>> GetPilotos()
        {
            return await repo.GetPilotos();
        }
    }
}
