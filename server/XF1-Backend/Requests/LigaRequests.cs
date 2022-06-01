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

        public static string getPuntajePublicaPorUsuario(string correo) { return $@"SELECT PP.Posicion, PP.Jugador, PP.Escuderia, PP.Equipo, PP.Puntos, PP.Correo
                                                                                                FROM PuntajesPublica AS PP JOIN USUARIO AS USU ON PP.Jugador = USU.NombreUsuario 
                                                                                                WHERE USU.Correo = {correo}
                                                                                                ORDER BY Puntos DESC"; }

        public static string getPuntajePrivadaPorUsuario(string correo) { return $@"SELECT PP.Posicion, PP.Jugador, PP.Escuderia, PP.Equipo, PP.Puntos, PP.Correo  
                                                                                                FROM PuntajesPrivada AS PP JOIN USUARIO AS USU ON PP.IdLiga = USU.IdLigaPrivada 
                                                                                                WHERE USU.Correo = {correo}
                                                                                                ORDER BY Puntos DESC"; }

        public static string getInfoLigaPrivada(string correo) { return $@"SELECT Count(PP.Jugador) AS Cantidad, MAX(PP.IdLiga) AS IdLiga, MAX(LIG.Activa) AS Activa 
                                                                                                FROM (PuntajesPrivada AS PP INNER JOIN USUARIO AS USU ON PP.IdLiga = USU.IdLigaPrivada)
                                                                                                JOIN LIGA AS LIG ON LIG.IdLiga = USU.IdLigaPrivada
                                                                                                WHERE USU.Correo = {correo}"; }

        public static string getUsuariosLiga(string correo) { return $@"SELECT DISTINCT PP.Jugador AS Jugador
                                                                                                FROM PuntajesPrivada AS PP INNER JOIN USUARIO AS USU ON PP.IdLiga = USU.IdLigaPrivada
                                                                                                WHERE USU.Correo = {correo}"; }

        public static string GetDisponibilidaLigaPrivada(string correo) { return $@"SELECT Count(PP.Jugador) AS Cantidad
                                                                                                FROM (PuntajesPrivada AS PP INNER JOIN USUARIO AS USU ON PP.IdLiga = USU.IdLigaPrivada)
	                                                                                            JOIN LIGA AS LIG ON LIG.IdLiga = USU.IdLigaPrivada	
                                                                                                WHERE USU.Correo = {correo}"; }

        public static string GetCampeonatoActual = "SELECT Id AS IdActual FROM CAMPEONATO WHERE FechaInicio < GETDATE() AND FechaFin > GETDATE()";

        public static string GetLigasPrivada = "SELECT * FROM LIGA WHERE Tipo = \'Privada\'";

        public static System.FormattableString AnadirNuevaLiga (string idLiga, string idCampeonato, string nombre ,string correo) { return $@"EXECUTE sp_formar_liga_privada @IdLigaPrivada = {idLiga}, @Campeonato = {idCampeonato}, @Nombre = {nombre}, @Correo = {correo}"; }
    }
}
