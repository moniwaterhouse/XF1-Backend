using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Requests
{
    /*
     * Esta clase contiene los requests relacionados a las carreras
     */
    public class CarreraRequests
    {
        // obtener todas las carreras
        public static string getCarreras = "SELECT * FROM CARRERA";

        // obtener las carreras que corresponden a un campeonato en esepecífico
        public static System.FormattableString getCarreraPorCampeonato(string id) { return $@"SELECT * FROM CARRERA WHERE IdCampeonato = {id}"; }

        // obtener las fechas de carreras que corresponden a un campeonato en específico
        public static System.FormattableString getFechasPorCampeonato(string id) { return $@"SELECT FechaInicio, FechaFin FROM CARRERA WHERE IdCampeonato = {id} ORDER BY FechaInicio DESC"; }

    }
}
