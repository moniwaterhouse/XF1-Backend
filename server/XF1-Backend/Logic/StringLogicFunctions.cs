using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using XF1_Backend.Models;

namespace XF1_Backend.Logic
{
    public class StringLogicFunctions
    {
        /*
         * Descripcion: esta funcion toma un texto y lo encripta con MD5
         * Entradas: contraseña sin encriptar
         * Salida: contraseña encriptada
         */
        public static string EncriptarContrasena(string contrasena)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(contrasena));

            byte[] resultado = md5.Hash;

            StringBuilder newContrasena = new StringBuilder();

            for (int i = 0; i < resultado.Length; i++)
            {
                newContrasena.Append(resultado[i].ToString("x2"));
            }

            return newContrasena.ToString();
        }

        /*
         * Descripcion: esta funcion verifica que el nombre sea de 5 a 30 caracteres
         * Entradas: nombre
         * Salida: booleano que indica si el nombre es de 5 a 30 caracteres o no
         */
        public static bool LongitudNombre(string nombre)
        {
            if(nombre.Length >= 5 && nombre.Length <= 30)
            {
                return true;
            }

            return false;

        }

        /*
         * Descripcion: esta funcion verifica que la descripcion del campeonato
         * sea menor o igual a 1000 caracteres
         * Entradas: descripcion del campeonato
         * Salida: booleano que indica si el nombre del campeonato es menor o
         * igual a 1000 caracteres
         */
        public static bool LongitudDescripcionCampeonato(string descripcion)
        {
            if (descripcion.Length <= 1000)
            {
                return true;
            }

            return false;

        }

        /*
         * Descripcion: esta funcion verifica que el nombre de usuario sea de
         * 1 a 30 caracteres
         * Entradas: nombre de usuario
         * Salida: booleano que indica si el nombre de usuario es de 5 a 30
         * caracteres o no
         */
        public static bool LongitudNombreUsuario(string nombreUsuario)
        {
            if (nombreUsuario.Length >= 1 && nombreUsuario.Length <= 30)
            {
                return true;
            }

            return false;

        }

        /*
        * Descripcion: esta funcion verifica que la contraseña del usuario
        * sea de 8 caracteres alfanuméricos
        * Entradas: contraseña del usuario
        * Salida: booleano que indica si la contraseña del usuario es de
        * 8 caracteres alfanuméricos
        */
        public static bool LongitudContrasena(string contrasena)
        {
            if (contrasena.Length == 8 && contrasena.All(char.IsLetterOrDigit))
            {
                return true;
            }

            return false;

        }

        /*
        * Descripcion: esta funcion verifica que el correo del usuario sea único
        * Entradas:
        * correoUsuario -> correo del usuario
        * correos -> lista de los correos registrados
        * Salida: booleano que indica si el correo del usuario es único
        */
        public static bool RevisarCorreo(string correoUsuario, IEnumerable<CorreoUsuario> correos)
        {
            foreach (var correo in correos)
            {
                if(correoUsuario.Equals(correo))
                {
                    return false;
                }
            }

            return true;

        }

    }

}
