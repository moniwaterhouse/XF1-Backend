using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XF1_Backend.Models;

namespace XF1_Backend.Logic
{
    public class LogicFunctions
    {
        /*
         * Descripcion: esta funcion carga un nuevo identificador para cualquier tabla que necesite
         * un identificador numerico entero basado en los id que ya existen.
         * Input: carreras -> es una lista de las cerreras existentes.
         * Output: newId -> un entero correspondiente al nuevo id.
         */
        public static int GenerarId(IEnumerable<Id> ids)
        {
            int newId = 1;

            foreach (var id in ids)
            {
                if (id.IdNum >= newId) newId = id.IdNum + 1;
            }

            return newId;

        }

        /*
         * Descripcióon: esta funcion genera una nueva llave de 6 caracteres alfanumericos
         * para diferenciar las carreras entre sí. La idea es que este no se repita con
         * llaves ya existentes.
         */
        public static string GenerarLlave(IEnumerable<Campeonato> campeonatos)
        {
            Random rd = new Random();
            string possibleCharacters = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";

            string key = "";
            int rand_num;

            for (int i = 0; i < 6; i++)
            {
                rand_num = rd.Next(0, 35);
                key += possibleCharacters[rand_num];
            }

            foreach (var campeonato in campeonatos)
            {
                if (campeonato.Id == key) return GenerarLlave(campeonatos);
            }

            return key;
        }

        /*
         * Descripcion: Dada una lista de fechas ocupadas revisa que las fechas de inico y final no coincidan
         * en ninguno de los rangos posibles.
         * Entradas:
         * fechaInicio, fechaFinal -> fechas del rango que se desea añadir
         * fechas -> lista de las fechas actuales.
         * Salida: boleano que indica si hay un choque de fechas o no.
         */
        public static bool RevisarFechas(DateTime fechaInicio, DateTime fechaFinal, IEnumerable<Fechas> fechas)
        {

            foreach (var fecha in fechas)
            {
                if (DateTime.Compare(fechaInicio, fecha.FechaInicio) >= 0 &&
                    DateTime.Compare(fechaInicio, fecha.FechaFin) <= 0) return false;

                if (DateTime.Compare(fechaFinal, fecha.FechaInicio) >= 0 &&
                    DateTime.Compare(fechaFinal, fecha.FechaFin) <= 0) return false;

                if (DateTime.Compare(fechaInicio, fecha.FechaInicio) <= 0 &&
                    DateTime.Compare(fechaFinal, fecha.FechaFin) >= 0) return false;
            }

            return true;
        }

        /*
         * Descripcion: esta funcion toma un texto y lo encripta con MD5
         * Entradas: contraseña sin encriptas
         * Salida: contraseña encriptada
         */
        public static string EncriptarContrasena(string contrasena)
        {
            return "Contraseña encriptada";
        }
    }
}
