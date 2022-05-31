using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XF1_Backend.Models;


namespace XF1_Backend.Logic
{
    public class DateLogicFunctions
    {
        /*
         * Descripción: Dada una lista de fechas ocupadas revisa que las fechas de inico y final no coincidan
         * en ninguno de los rangos posibles.
         * Entradas:
         * fechaInicio, fechaFinal -> fechas del rango que se desea añadir
         * fechas -> lista de las fechas actuales.
         * Salida: boleano que indica si hay un choque de fechas o no.
         */
        public static bool RevisarFechas(DateTime fechaInicio, DateTime fechaFin, IEnumerable<Fechas> fechas)
        {

            foreach (var fecha in fechas)
            {
                if (DateTime.Compare(fechaInicio, fecha.FechaInicio) >= 0 &&
                    DateTime.Compare(fechaInicio, fecha.FechaFin) <= 0) return false;

                if (DateTime.Compare(fechaFin, fecha.FechaInicio) >= 0 &&
                    DateTime.Compare(fechaFin, fecha.FechaFin) <= 0) return false;

                if (DateTime.Compare(fechaInicio, fecha.FechaInicio) <= 0 &&
                    DateTime.Compare(fechaFin, fecha.FechaFin) >= 0) return false;
            }

            return true;
        }
    }
}