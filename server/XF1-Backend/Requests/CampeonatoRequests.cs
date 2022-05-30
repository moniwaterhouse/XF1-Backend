using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XF1_Backend.Models;

namespace XF1_Backend.Requests
{
    /*
     * Esta clase contiene los requests relacionados a los campeonatos
     */
    public class CampeonatoRequests
    {
        // obtener todos los campeonatos
        public static string getCampeonatos = "SELECT * FROM CAMPEONATO ORDER BY FechaInicio ASC";

        // obtener fechas de los campeonatos
        public static string getFechasCampeonatos = "SELECT CAMPEONATO.FechaInicio, CAMPEONATO.FechaFin FROM CAMPEONATO";

        // stored procedure para crear liga
        public static System.FormattableString crearLiga(string id, int activa) { return $@"EXECUTE sp_crear_liga_publica {id}, {activa}"; }

        // obtener fechas de los campeonatos
        public static string getFechas =    "SELECT CAMPEONATO.FechaInicio, CAMPEONATO.FechaFin " +
                                            "FROM CAMPEONATO";

        // obtener los nombres de los campeonatos
        public static string getNombres = "SELECT Id, Nombre, FechaInicio, FechaFin" +
                                          " FROM CAMPEONATO ORDER BY FechaInicio DESC";


    }

}
