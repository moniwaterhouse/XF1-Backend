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
    public class CompetenciaController : ControllerBase
    {
        private readonly CompetenciaDbContext _context;

        public CompetenciaController(CompetenciaDbContext context)
        {
            _context = context;
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Competencia>> PostCompetencias(Competencia competencia)
        {
            try
            {
                _context.Competencia.Add(competencia);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return Conflict("there was a conflict");
            }
        }


    }
}
