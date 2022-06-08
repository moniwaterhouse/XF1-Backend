using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using XF1_Backend.Logic;
using XF1_Backend.Models;
using System;

namespace XF1_Backend_Unit_Testing
{
    [TestClass]
    public class IntLogicTests
    {
        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * CantidadJugadoresLigaPrivada no sea un valor nulo.
          */
        [TestMethod]
        public void CantidadJugadoresLigaPrivada_NoNulo_Test()
        {
            CantidadJugador cantidadJugador =  new CantidadJugador();
            cantidadJugador.Cantidad = 15;           

            bool resultado = IntLogicFunctions.CantidadJugadoresLigaPrivada(cantidadJugador);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * CantidadJugadoresLigaPrivada retorne un valor booleano True si la cantidad
          * de jugadores es menor o igual a 20.
          */
        [TestMethod]
        public void CantidadJugadoresLigaPrivada_CantidadCorrecta_Test()
        {
            CantidadJugador cantidadJugador = new CantidadJugador();
            cantidadJugador.Cantidad = 15;

            bool resultado = IntLogicFunctions.CantidadJugadoresLigaPrivada(cantidadJugador);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * CantidadJugadoresLigaPrivada retorne un valor booleano False si la cantidad
          * de jugadores es mayor a 20.
          */
        [TestMethod]
        public void LongitudNombre_CantidadIncorrecta_Test()
        {
            CantidadJugador cantidadJugador = new CantidadJugador();
            cantidadJugador.Cantidad = 50;

            bool resultado = IntLogicFunctions.CantidadJugadoresLigaPrivada(cantidadJugador);

            Assert.IsFalse(resultado);

        }

    }

}
