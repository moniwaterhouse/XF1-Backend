using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using XF1_Backend.Logic;
using XF1_Backend.Models;
using System;

namespace XF1_Backend_Unit_Testing
{
    [TestClass]
    public class StringLogicTests
    {
        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * EncriptarContrasena no sea un valor nulo.
         */
        [TestMethod]
        public void EncriptarContrasena_NoNulo_Test()
        {
            string contrasena = "especificacion";

            string resultado = StringLogicFunctions.EncriptarContrasena(contrasena);

            Assert.IsNotNull(resultado);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * EncriptarContrasena no sea igual a la contrasena de entrada.
         */
        [TestMethod]
        public void EncriptarContrasena_ContrasenaDiferente_Test()
        {
            string contrasena = "especificacion";

            string resultado = StringLogicFunctions.EncriptarContrasena(contrasena);

            Assert.AreNotEqual(resultado, contrasena);

        }

    }
}
