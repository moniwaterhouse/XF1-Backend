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

            bool permitido;

            // revisión de valores nulos           
            permitido = NullValuesLogicFunctions.ValoresNulosCampeonato(campeonato);
            if (permitido == false) return Conflict("Se requieren todos los datos del campeonato");

            // revisión de la longitud del nombre del campeonato
            permitido = StringLogicFunctions.LongitudNombreCampeonato(campeonato.Nombre);
            if (permitido == false) return Conflict("El nombre del campeonato de ser de 5 a 30 caracteres");

            // revisión de la longitud de la descripción del campeonato
            permitido = StringLogicFunctions.LongitudDescripcionCampeonato(campeonato.ReglasPuntuacion);
            if (permitido == false) return Conflict("La descripción del campeonato de ser de máximo 1000 caracteres");
            
            // generar llave unica del campeonato
            IEnumerable<Campeonato> campeonatosAnteriores;
            campeonatosAnteriores = await _context.Campeonato.FromSqlRaw(CampeonatoRequests.getCampeonatos).ToListAsync();
            campeonato.Id = IdLogicFunctions.GenerarLlave(campeonatosAnteriores);

            // revision de choque de fechas
            IEnumerable<Fechas> fechas;
            fechas = await _context.Fechas.FromSqlRaw(CampeonatoRequests.getFechasCampeonatos).ToListAsync();
            permitido = DateLogicFunctions.RevisarFechas(campeonato.FechaInicio, campeonato.FechaFin, fechas);
            if (permitido == false) return Conflict("Existe un conflicto de fechas con otro campeonato");


            // revisión de fechas anteriores a la actual
            permitido = DateLogicFunctions.RevisarFechasAnteriores(campeonato.FechaInicio, campeonato.FechaFin);
            if (permitido == false) return Conflict("No se puede crear un campeonato con una fecha menor a la actual");

            // añadir campeonato
            _context.Campeonato.Add(campeonato);
            await _context.SaveChangesAsync();

            // crear liga publica y añadir los jugadoers ahí
            await _context.Database.ExecuteSqlInterpolatedAsync(CampeonatoRequests.crearLiga(campeonato.Id, 0));
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
