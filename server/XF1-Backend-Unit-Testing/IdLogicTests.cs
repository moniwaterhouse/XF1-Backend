using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using XF1_Backend.Logic;
using XF1_Backend.Models;
using System;

namespace XF1_Backend_Unit_Testing
{
    [TestClass]
    public class IdLogicTests
    {
        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * GenerarId no sea un valor nulo.
         */
        [TestMethod]
        public void GenerarId_NoNulo_Test()
        {
            List<Id> carreraIds = new List<Id>();

            for (int i = 0; i < 10; i++)
            {
                Id newId = new Id();
                newId.IdNum = i;
                carreraIds.Add(newId);
            }

            int resultado = IdLogicFunctions.GenerarId(carreraIds);

            Assert.IsNotNull(resultado);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * GenerarId sea un identificador numerico entero basado en los id que ya
         * existen.
         */
        [TestMethod]
        public void GenerarId_Cantidad_Test()
        {
            List<Id> carreraIds = new List<Id>();

            for (int i = 0; i < 10; i++)
            {
                Id newId = new Id();
                newId.IdNum = i;
                carreraIds.Add(newId);
            }

            int resultado = IdLogicFunctions.GenerarId(carreraIds);

            Assert.AreEqual(resultado, carreraIds.Count);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * GenerarLlave no sea un valor nulo.
         */
        [TestMethod]
        public void GenerarLlave_NoNulo_Test()
        {
            Campeonato campeonato1 = new Campeonato();
            campeonato1.Id = "23F6SH";

            Campeonato campeonato2 = new Campeonato();
            campeonato2.Id = "KL9HY6";

            Campeonato campeonato3 = new Campeonato();
            campeonato3.Id = "PESVY9";

            Campeonato campeonato4 = new Campeonato();
            campeonato4.Id = "N0U1M7";

            Campeonato campeonato5 = new Campeonato();
            campeonato5.Id = "MD4HR8";

            List<Campeonato> campeonatosIds = new List<Campeonato>();

            campeonatosIds.Add(campeonato1);
            campeonatosIds.Add(campeonato2);
            campeonatosIds.Add(campeonato3);
            campeonatosIds.Add(campeonato4);
            campeonatosIds.Add(campeonato5);

            string resultado = IdLogicFunctions.GenerarLlave(campeonatosIds);

            Assert.IsNotNull(resultado);

        }


        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * GenerarLlave genere un string de 6 caracteres.
         */
        [TestMethod]
        public void GenerarLlave_6Caracteres_Test()
        {
            Campeonato campeonato1 = new Campeonato();
            campeonato1.Id = "23F6SH";

            Campeonato campeonato2 = new Campeonato();
            campeonato2.Id = "KL9HY6";

            Campeonato campeonato3 = new Campeonato();
            campeonato3.Id = "PESVY9";

            Campeonato campeonato4 = new Campeonato();
            campeonato4.Id = "N0U1M7";

            Campeonato campeonato5 = new Campeonato();
            campeonato5.Id = "MD4HR8";

            List<Campeonato> campeonatosIds = new List<Campeonato>();

            campeonatosIds.Add(campeonato1);
            campeonatosIds.Add(campeonato2);
            campeonatosIds.Add(campeonato3);
            campeonatosIds.Add(campeonato4);
            campeonatosIds.Add(campeonato5);

            string resultado = IdLogicFunctions.GenerarLlave(campeonatosIds);

            Assert.AreEqual(resultado.Length, 6);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * GenerarLlave genere un string de 6 caracteres diferente a los ya
         * existentes.
         */
        [TestMethod]
        public void GenerarLlave_LlaveDiferente_Test()
        {
            Campeonato campeonato1 = new Campeonato();
            campeonato1.Id = "23F6SH";

            Campeonato campeonato2 = new Campeonato();
            campeonato2.Id = "KL9HY6";

            Campeonato campeonato3 = new Campeonato();
            campeonato3.Id = "PESVY9";

            Campeonato campeonato4 = new Campeonato();
            campeonato4.Id = "N0U1M7";

            Campeonato campeonato5 = new Campeonato();
            campeonato5.Id = "MD4HR8";

            List<Campeonato> campeonatosIds = new List<Campeonato>();

            campeonatosIds.Add(campeonato1);
            campeonatosIds.Add(campeonato2);
            campeonatosIds.Add(campeonato3);
            campeonatosIds.Add(campeonato4);
            campeonatosIds.Add(campeonato5);

            string resultado = IdLogicFunctions.GenerarLlave(campeonatosIds);

            Assert.AreNotEqual(resultado, "23F6SH");
            Assert.AreNotEqual(resultado, "KL9HY6");
            Assert.AreNotEqual(resultado, "PESVY9");
            Assert.AreNotEqual(resultado, "N0U1M7");
            Assert.AreNotEqual(resultado, "MD4HR8");

        }

    }
}
