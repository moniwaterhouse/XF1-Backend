using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Requests
{
    /*
     * Esta clase contiene los requests relacionados a los datos de los usuarios
     */
    public class UsuarioRequests
    {
        // Obtener todos los correos
        public static string getCorreos = "SELECT Correo FROM USUARIO";

        // Obtener usuario por correo
        public static string getUsuarioPorCorreo(string correo) { return $@"SELECT * FROM USUARIO WHERE Correo = {correo}";  }

        // Obtener todos los nombres de escuderias
        public static string getEscuderias = "SELECT NombreEscuderia FROM USUARIO";

        // Stored procedure de añadir nuevo usuario a ligas publicas
        public static System.FormattableString anadirUsuarioLiga(string correo) { return $@"EXECUTE sp_anadir_usuario_liga {correo}"; }

        // obtener informacion del perfil de usuario
        public static string getPerfilUsuario(string correo) { return $@"SELECT USU.NombreUsuario, USU.Pais, USU.NombreEscuderia, EQU.MarcaEscuderia, EQU.Nombre AS NombreEquipo, EQU.NombrePiloto1, EQU.NombrePiloto2, EQU.NombrePiloto3, EQU.NombrePiloto4, EQU.NombrePiloto5
                                                                                        FROM USUARIO AS USU JOIN EQUIPO AS EQU ON (USU.IdEquipo1 = EQU.Id OR USU.IdEquipo2 = EQU.Id)
                                                                                        WHERE USU.Correo = {correo}"; }

    }
}
