using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Requests
{
    /*
     * Esta clase contiene los requests relacionados a las ligas
     */
    public class LigaRequests
    {
        public static string getPuntajesPublica =   "SELECT * " +
                                                    "FROM PuntajesPublica " +
                                                    "ORDER BY Puntos DESC";

        public static string getPuntajePublicaPorUsuario(string correo) { return $@"SELECT PP.Posicion, PP.Jugador, PP.Escuderia, PP.Equipo, PP.Puntos 
                                                                                                FROM PuntajesPublica AS PP JOIN USUARIO AS USU ON PP.Jugador = USU.NombreUsuario 
                                                                                                WHERE USU.Correo = {correo}
                                                                                                ORDER BY Puntos DESC"; }
    }
}
