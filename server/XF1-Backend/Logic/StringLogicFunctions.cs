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
         * Descripcion: esta funcion verifica que el nombre del campeonato
         * sea de 5 a 30 caracteres
         * Entradas: nombre del campeonato
         * Salida: booleano que indica si el nombre del campeonata es de
         * 5 a 30 caracteres o no
         */
        public static bool LongitudNombreCampeonato(string nombre)
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
         * Salida: booleano que indica si el nombre del campeonata es menor o
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












    }
}
