using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Models;

namespace XF1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenciasController : ControllerBase
    {
        private readonly CompetenciasDbContext _context;

        public CompetenciasController(CompetenciasDbContext context)
        {
            _context = context;
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Competencias>> PostCompetencias(Competencias competencias)
        {
            _context.Competencias.Add(competencias);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
