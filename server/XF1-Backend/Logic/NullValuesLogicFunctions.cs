using System;
using XF1_Backend.Models;

namespace XF1_Backend.Logic
{
    public class NullValuesLogicFunctions
    {

        /*
         * Descripcion: esta funcion verifica que todos los datos del campeonato no son nulos
         * Entradas: instancia de la clase Campeonato
         * Salida: booleano que indica si algún dato del campeonato es nulo o no, exceptuando
         * la descripción
         */
        public static bool ValoresNulosCampeonato(Campeonato campeonato)
        {
            if(campeonato.Id == null ||
               campeonato.Nombre == null ||
               campeonato.Presupuesto == 0 ||
               campeonato.FechaInicio == DateTime.MinValue ||
               campeonato.HoraInicio == null ||
               campeonato.FechaFin == DateTime.MinValue ||
               campeonato.HoraFin == null)
            {
                return false;                
            }

            return true;

        }

    }
}
