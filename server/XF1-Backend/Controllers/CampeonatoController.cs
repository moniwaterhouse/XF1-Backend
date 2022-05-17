﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Models;
using XF1_Backend.Logic;
using XF1_Backend.Requests;

namespace XF1_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        private readonly CampeonatoDbContext _context;

        public CampeonatoController(CampeonatoDbContext context)
        {
            _context = context;
        }

        // POST: api/Campeonato
        [HttpPost]
        public async Task<ActionResult<Campeonato>> PostCampeonatos(Campeonato campeonato)
        {

                // generar llave unica del campeonato
                campeonato.Id = LogicFunctions.GenerarLlave();

                // revision de choque de fechas
                IEnumerable<Fechas> fechas;
                fechas = await _context.Fechas.FromSqlRaw(CampeonatoRequests.getFechasCampeonatos).ToListAsync();
                bool permitido = LogicFunctions.RevisarFechas(campeonato.FechaInicio, campeonato.FechaFin, fechas);
                if (permitido == false) return Conflict("Existe un conflicto de fechas con otro campeonato");

                // añadir campeonato
                _context.Campeonato.Add(campeonato);
                await _context.SaveChangesAsync();

                // crear liga publica y añadir los jugadoers ahí
                await _context.Database.ExecuteSqlInterpolatedAsync(CampeonatoRequests.crearLiga(campeonato.Id));
                await _context.SaveChangesAsync();

                return Ok();

        }

        // GET api/Campeonato
        [HttpGet]
        public async Task<IEnumerable<Campeonato>> GetCampeonatos()
        {
            return await _context.Campeonato.FromSqlRaw(CampeonatoRequests.getCampeonatos).ToListAsync();
        }

        // GET api/Campeonato/Fechas
        [HttpGet("Fechas")]
        public async Task<IEnumerable<Fechas>> GetFechas()
        {
            return await _context.Fechas.FromSqlRaw(CampeonatoRequests.getFechas).ToListAsync();
        }

        // GET api/Campeonato/Nombres
        [HttpGet("Nombres")]
        public async Task<IEnumerable<Nombres>> GetNombres()
        {
            return await _context.Nombres.FromSqlRaw(CampeonatoRequests.getNombres).ToListAsync();
        }


    }
}
