using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using XF1_Backend.Logic;
using XF1_Backend.Models;
using XF1_Backend.Repositories;

namespace XF1_Backend.Services
{
    public class LigaService : ControllerBase
    {
        public ObjectResult NullValidations(NuevaLiga liga)
        {
            // revisión de valores nulos         
            bool permitido = NullValuesLogicFunctions.ValoresNulosNuevaLiga(liga);
            if (permitido == false) return StatusCode(409, "Se requieren todos los datos de la nueva liga");

            return StatusCode(200, "ok");
        }

        public ObjectResult StringValidations(NuevaLiga liga)
        {
            // revisión de la longitud del nombre de la nueva liga
            bool permitido = StringLogicFunctions.LongitudNombreNuevaLiga(liga.Nombre);
            if (permitido == false) return StatusCode(409, "El nombre de la nueva liga debe ser de máximo 30 caracteres alfanuméricos");

            return StatusCode(200, "ok");
        }

        public ObjectResult IdLigaPrivadaValidation(ActualizarLiga actualizarLiga, LigaRepository repo)
        {
            IEnumerable<IdPrivadas> idPrivadas = repo.GetIdPrivadas();
            bool permitido = IdLogicFunctions.RevisarIdLigaPrivada(actualizarLiga, idPrivadas);
            if (permitido == false) return StatusCode(409, "La llave insertada no pertenece a ninguna liga privada");

            return StatusCode(400, "Bad request");
        }

        public ObjectResult CantidadLigaValidations(ActualizarLiga actualizarLiga, LigaRepository repo)
        {
            CantidadJugador cantidadJugador = repo.GeCantidadLigaPrivada(actualizarLiga.Id);
            bool permitido = IntLogicFunctions.CantidadJugadoresLigaPrivada(cantidadJugador);
            if (permitido == false) return StatusCode(409, "La liga privada ya no tiene espacio disponible");

            return StatusCode(400, "Bad request");
        }

    }
}
