using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Models;
using XF1_Backend.Logic;
using XF1_Backend.Requests;
using Microsoft.AspNetCore.Mvc;


namespace XF1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotoController : ControllerBase
    {
        private readonly PilotoDbContext _context;

        public PilotoController(PilotoDbContext context)
        {
            _context = context;
        }

        // GET api/Piloto
        [HttpGet]
        public async Task<IEnumerable<Piloto>> GetPilotos()
        {
            return await _context.Pilotos.FromSqlRaw(PilotoRequests.GetPilotos).ToListAsync();
        }
    }
}
