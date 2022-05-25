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
    public class EscuderiaController : ControllerBase
    {
        private readonly EscuderiaDbContext _context;

        public EscuderiaController(EscuderiaDbContext context)
        {
            _context = context;
        }

        // GET api/Escuderia
        [HttpGet]
        public async Task<IEnumerable<Escuderia>> GetEscuderias()
        {
            return await _context.Escuderia.FromSqlRaw(EscuderiaRequests.GetEscuderias).ToListAsync();
        }

    }
}
