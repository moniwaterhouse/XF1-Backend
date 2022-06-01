using System;
using XF1_Backend.Models;

namespace XF1_Backend.Logic
{
    public class NullValuesLogicFunctions
    {
        /*
         * Descripcion: esta funcion verifica que todos los datos del campeonato no sean nulos
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

        /*
         * Descripcion: esta funcion verifica que todos los datos de una carrera no sean nulos
         * Entradas: instancia de la clase Campeonato
         * Salida: booleano que indica si algún dato de la carrera es nulo o no
         */
        public static bool ValoresNulosCarrera(Carrera carrera)
        {
            if(carrera.Id == null ||
               carrera.IdCampeonato == null ||
               carrera.Nombre == null ||
               carrera.NombrePais == null ||
               carrera.NombrePista == null ||
               carrera.FechaInicio == DateTime.MinValue ||
               carrera.HoraInicio == null ||
               carrera.FechaFin == DateTime.MinValue ||
               carrera.HoraFin == null ||
               carrera.Estado == null)
            {
                return false;
            }

            return true;

        }




        
        
        
        
        
        
        
        







    }

}
