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

        // obtener nombre del campeonato a partir de la carrera
        public static string getCarrerasNombreCampeonato = "SELECT CAR.Id , CAM.Nombre AS NombreCampeonato, CAR.Nombre, CAR.NombrePais, CAR.NombrePista, CAR.FechaInicio, CAR.HoraInicio, CAR.FechaFin, CAR.HoraFin, CAR.Estado " +
                                                   "FROM CARRERA AS CAR JOIN CAMPEONATO AS CAM ON CAR.IdCampeonato = CAM.Id";

        public int Id { get; set; }
        public string NombreCampeonato { get; set; }
        public string Nombre { get; set; }
        public string NombrePais { get; set; }
        public string NombrePista { get; set; }
        public DateTime FechaInicio { get; set; }
        public string HoraInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string HoraFin { get; set; }
        public string Estado { get; set; }

        // obtener las carreras que corresponden a un campeonato en esepecífico
        public static System.FormattableString getCarreraPorCampeonato(string id) { return $@"SELECT Id AS IdNum FROM CARRERA WHERE IdCampeonato = {id}"; }

        // obtener las fechas de carreras que corresponden a un campeonato en específico
        public static System.FormattableString getFechasPorCampeonato(string id) { return $@"SELECT FechaInicio, FechaFin FROM CARRERA WHERE IdCampeonato = {id} ORDER BY FechaInicio DESC"; }

    }
}
