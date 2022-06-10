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
         * Entradas: instancia de la clase Carrera
         * Salida: booleano que indica si algún dato de la carrera es nulo o no
         */
        public static bool ValoresNulosCarrera(Carrera carrera)
        {
            if(carrera.IdCampeonato == null ||
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

        /*
         * Descripcion: esta funcion verifica que todos los datos del usuario no sean nulos
         * Entradas: instancia de la clase Usuario
         * Salida: booleano que indica si algún dato de la carrera es nulo o no
         */
        public static bool ValoresNulosUsuario(Usuario usuario)
        {
            if(usuario.NombreUsuario == null ||
               usuario.Correo == null ||
               usuario.Pais == null ||
               usuario.Contrasena == null ||
               usuario.NombreEscuderia == null)
            {
                return false;
            }

            return true;

        }

        /*
         * Descripcion: esta funcion verifica que todos los datos del equipo no sean nulos
         * Entradas: instancia de la clase Equipo
         * Salida: booleano que indica si algún dato del equipo es nulo o no
         */
        public static bool ValoresNulosEquipo(Equipo equipo)
        {
            if(equipo.MarcaEscuderia == null ||
               equipo.NombrePiloto1 == null ||
               equipo.NombrePiloto2 == null ||
               equipo.NombrePiloto3 == null ||
               equipo.NombrePiloto4 == null ||
               equipo.NombrePiloto5 == null)
            {
                return false;
            }

            return true;

        }

        /*
         * Descripcion: esta funcion verifica que todos los datos de la nueva liga no sean nulos
         * Entradas: instancia de la clase NuevaLiga
         * Salida: booleano que indica si algún dato dela nueva liga es nulo o no
         */
        public static bool ValoresNulosNuevaLiga(NuevaLiga nuevaLiga)
        {
            if(nuevaLiga.Nombre == null ||
               nuevaLiga.Correo == null)
            {
                return false;
            }

            return true;

        }

    }

}
