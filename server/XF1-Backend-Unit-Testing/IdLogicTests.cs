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
         * GenerarLlaveCampeonato no sea un valor nulo.
         */
        [TestMethod]
        public void GenerarLlaveCampeonato_NoNulo_Test()
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

            string resultado = IdLogicFunctions.GenerarLlaveCampeonato(campeonatosIds);

            Assert.IsNotNull(resultado);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * GenerarLlaveCampeonato genere un string de 6 caracteres.
         */
        [TestMethod]
        public void GenerarLlaveCampeonato_6Caracteres_Test()
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

            string resultado = IdLogicFunctions.GenerarLlaveCampeonato(campeonatosIds);

            Assert.AreEqual(resultado.Length, 6);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * GenerarLlaveCampeonato genere un string de 6 caracteres diferente a los
         * ya existentes.
         */
        [TestMethod]
        public void GenerarLlaveCampeonato_LlaveDiferente_Test()
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

            string resultado = IdLogicFunctions.GenerarLlaveCampeonato(campeonatosIds);

            Assert.AreNotEqual(resultado, "23F6SH");
            Assert.AreNotEqual(resultado, "KL9HY6");
            Assert.AreNotEqual(resultado, "PESVY9");
            Assert.AreNotEqual(resultado, "N0U1M7");
            Assert.AreNotEqual(resultado, "MD4HR8");

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * GenerarLlaveLigaPrivada no sea un valor nulo.
         */
        [TestMethod]
        public void GenerarLlaveLigaPrivada_NoNulo_Test()
        {
            CampeonatoActual llaveActual = new CampeonatoActual();
            llaveActual.IdActual = "KL9HY6";

            Liga liga1 = new Liga();
            liga1.IdLiga = "KL9HY6-23F6SH";

            Liga liga2 = new Liga();
            liga2.IdLiga = "KL9HY6-KL9HY6";

            Liga liga3 = new Liga();
            liga3.IdLiga = "KL9HY6-PESVY9";

            Liga liga4 = new Liga();
            liga4.IdLiga = "KL9HY6-N0U1M7";

            Liga liga5 = new Liga();
            liga5.IdLiga = "KL9HY6-MD4HR8";

            List<Liga> ligasPrivadas = new List<Liga>();

            ligasPrivadas.Add(liga1);
            ligasPrivadas.Add(liga2);
            ligasPrivadas.Add(liga3);
            ligasPrivadas.Add(liga4);
            ligasPrivadas.Add(liga5);

            string resultado = IdLogicFunctions.GenerarLlaveLigaPrivada(llaveActual, ligasPrivadas);

            Assert.IsNotNull(resultado);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * GenerarLlaveLigaPrivada genere un string de 13 caracteres.
         */
        [TestMethod]
        public void GenerarLlaveLigaPrivada_13Caracteres_Test()
        {
            CampeonatoActual llaveActual = new CampeonatoActual();
            llaveActual.IdActual = "KL9HY6";

            Liga liga1 = new Liga();
            liga1.IdLiga = "KL9HY6-23F6SH";

            Liga liga2 = new Liga();
            liga2.IdLiga = "KL9HY6-KL9HY6";

            Liga liga3 = new Liga();
            liga3.IdLiga = "KL9HY6-PESVY9";

            Liga liga4 = new Liga();
            liga4.IdLiga = "KL9HY6-N0U1M7";

            Liga liga5 = new Liga();
            liga5.IdLiga = "KL9HY6-MD4HR8";

            List<Liga> ligasPrivadas = new List<Liga>();

            ligasPrivadas.Add(liga1);
            ligasPrivadas.Add(liga2);
            ligasPrivadas.Add(liga3);
            ligasPrivadas.Add(liga4);
            ligasPrivadas.Add(liga5);

            string resultado = IdLogicFunctions.GenerarLlaveLigaPrivada(llaveActual, ligasPrivadas);

            Assert.AreEqual(resultado.Length, 13);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * GenerarLlaveLigaPrivada genere un string de 13 caracteres diferente a los
         * ya existentes.
         */
        [TestMethod]
        public void GenerarLlaveLigaPrivada_LlaveDiferente_Test()
        {
            CampeonatoActual llaveActual = new CampeonatoActual();
            llaveActual.IdActual = "KL9HY6";

            Liga liga1 = new Liga();
            liga1.IdLiga = "KL9HY6-23F6SH";

            Liga liga2 = new Liga();
            liga2.IdLiga = "KL9HY6-KL9HY6";

            Liga liga3 = new Liga();
            liga3.IdLiga = "KL9HY6-PESVY9";

            Liga liga4 = new Liga();
            liga4.IdLiga = "KL9HY6-N0U1M7";

            Liga liga5 = new Liga();
            liga5.IdLiga = "KL9HY6-MD4HR8";

            List<Liga> ligasPrivadas = new List<Liga>();

            ligasPrivadas.Add(liga1);
            ligasPrivadas.Add(liga2);
            ligasPrivadas.Add(liga3);
            ligasPrivadas.Add(liga4);
            ligasPrivadas.Add(liga5);

            string resultado = IdLogicFunctions.GenerarLlaveLigaPrivada(llaveActual, ligasPrivadas);

            Assert.AreNotEqual(resultado, "KL9HY6-23F6SH");
            Assert.AreNotEqual(resultado, "KL9HY6-KL9HY6");
            Assert.AreNotEqual(resultado, "KL9HY6-PESVY9");
            Assert.AreNotEqual(resultado, "KL9HY6-N0U1M7");
            Assert.AreNotEqual(resultado, "KL9HY6-MD4HR8");

        }
        
        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * RevisarIdLigaPrivada no sea un valor nulo.
         */
        [TestMethod]
        public void RevisarIdLigaPrivada_NoNulo_Test()
        {
            ActualizarLiga actualizarLiga = new ActualizarLiga();
            actualizarLiga.Id = "KL9HY6-PESVY9";

            IdPrivadas idPrivadas1 = new IdPrivadas();
            idPrivadas1.Id = "KL9HY6-23F6SH";

            IdPrivadas idPrivadas2 = new IdPrivadas();
            idPrivadas2.Id = "KL9HY6-KL9HY6";

            IdPrivadas idPrivadas3 = new IdPrivadas();
            idPrivadas3.Id = "KL9HY6-PESVY9";

            IdPrivadas idPrivadas4 = new IdPrivadas();
            idPrivadas4.Id = "KL9HY6-N0U1M7";

            IdPrivadas idPrivadas5 = new IdPrivadas();
            idPrivadas5.Id = "KL9HY6-MD4HR8";

            List<IdPrivadas> idPrivadas = new List<IdPrivadas>();

            idPrivadas.Add(idPrivadas1);
            idPrivadas.Add(idPrivadas2);
            idPrivadas.Add(idPrivadas3);
            idPrivadas.Add(idPrivadas4);
            idPrivadas.Add(idPrivadas5);

            bool resultado = IdLogicFunctions.RevisarIdLigaPrivada(actualizarLiga, idPrivadas);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarIdLigaPrivada retorne un valor booleano True si el id de actualizarLiga
          * está registrado.
          */
        [TestMethod]
        public void RevisarIdLigaPrivada_IdRegistrado_Test()
        {
            ActualizarLiga actualizarLiga = new ActualizarLiga();
            actualizarLiga.Id = "KL9HY6-PESVY9";

            IdPrivadas idPrivadas1 = new IdPrivadas();
            idPrivadas1.Id = "KL9HY6-23F6SH";

            IdPrivadas idPrivadas2 = new IdPrivadas();
            idPrivadas2.Id = "KL9HY6-KL9HY6";

            IdPrivadas idPrivadas3 = new IdPrivadas();
            idPrivadas3.Id = "KL9HY6-PESVY9";

            IdPrivadas idPrivadas4 = new IdPrivadas();
            idPrivadas4.Id = "KL9HY6-N0U1M7";

            IdPrivadas idPrivadas5 = new IdPrivadas();
            idPrivadas5.Id = "KL9HY6-MD4HR8";

            List<IdPrivadas> idPrivadas = new List<IdPrivadas>();

            idPrivadas.Add(idPrivadas1);
            idPrivadas.Add(idPrivadas2);
            idPrivadas.Add(idPrivadas3);
            idPrivadas.Add(idPrivadas4);
            idPrivadas.Add(idPrivadas5);

            bool resultado = IdLogicFunctions.RevisarIdLigaPrivada(actualizarLiga, idPrivadas);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarIdLigaPrivada retorne un valor booleano False si el id de actualizarLiga
          * no está registrado.
          */
        [TestMethod]
        public void RevisarIdLigaPrivada_IdNoRegistrado_Test()
        {
            ActualizarLiga actualizarLiga = new ActualizarLiga();
            actualizarLiga.Id = "KL9HY6-H1O2L3";

            IdPrivadas idPrivadas1 = new IdPrivadas();
            idPrivadas1.Id = "KL9HY6-23F6SH";

            IdPrivadas idPrivadas2 = new IdPrivadas();
            idPrivadas2.Id = "KL9HY6-KL9HY6";

            IdPrivadas idPrivadas3 = new IdPrivadas();
            idPrivadas3.Id = "KL9HY6-PESVY9";

            IdPrivadas idPrivadas4 = new IdPrivadas();
            idPrivadas4.Id = "KL9HY6-N0U1M7";

            IdPrivadas idPrivadas5 = new IdPrivadas();
            idPrivadas5.Id = "KL9HY6-MD4HR8";

            List<IdPrivadas> idPrivadas = new List<IdPrivadas>();

            idPrivadas.Add(idPrivadas1);
            idPrivadas.Add(idPrivadas2);
            idPrivadas.Add(idPrivadas3);
            idPrivadas.Add(idPrivadas4);
            idPrivadas.Add(idPrivadas5);

            bool resultado = IdLogicFunctions.RevisarIdLigaPrivada(actualizarLiga, idPrivadas);

            Assert.IsFalse(resultado);

        }

    }

}
