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
    public class CarreraController : ControllerBase
    {
        private readonly CarreraDbContext _context;

        public CarreraController(CarreraDbContext context)
        {
            _context = context;
        }

        // POST:
        [HttpPost]
        public async Task<ActionResult<Carrera>> PostCampeonatos(Carrera carrera)
        {
            try
            {
              
                _context.Carrera.Add(carrera);
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
