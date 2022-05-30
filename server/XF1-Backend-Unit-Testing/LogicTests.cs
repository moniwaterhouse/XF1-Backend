using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using XF1_Backend.Logic;
using XF1_Backend.Models;
using System;

namespace XF1_Backend_Unit_Testing
{
    [TestClass]
    public class LogicTests
    {
        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * GenerarId no sea un valor nulo.
         */
        [TestMethod]
        public void GenerarId_No_Nulo_Test()
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
        public void GenerarLlave_No_Nulo_Test()
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
        public void GenerarLlave_6_Caracteres_Test()
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
        public void GenerarLlave_Llave_Diferente_Test()
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

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarFechas no sea un valor nulo.
          */
        [TestMethod]
        public void RevisarFechas_No_Nulo_Test()
        {
            DateTime fechaInicio = new DateTime(2022, 12, 7);
            DateTime fechaFin = new DateTime(2022, 12, 19);

            Fechas fecha1 = new Fechas();
            fecha1.FechaInicio = new DateTime(2021, 1, 10);
            fecha1.FechaFin = new DateTime(2021, 1, 20);

            Fechas fecha2 = new Fechas();
            fecha2.FechaInicio = new DateTime(2021, 5, 27);
            fecha2.FechaFin = new DateTime(2021, 6, 5);

            Fechas fecha3 = new Fechas();
            fecha3.FechaInicio = new DateTime(2021, 11, 2);
            fecha3.FechaFin = new DateTime(2021, 11, 17);

            Fechas fecha4 = new Fechas();
            fecha4.FechaInicio = new DateTime(2021, 12, 26);
            fecha4.FechaFin = new DateTime(2022, 1, 10);

            Fechas fecha5 = new Fechas();
            fecha5.FechaInicio = new DateTime(2022, 7, 13);
            fecha5.FechaFin = new DateTime(2022, 7, 27);

            List<Fechas> fechas = new List<Fechas>();

            fechas.Add(fecha1);
            fechas.Add(fecha2);
            fechas.Add(fecha3);
            fechas.Add(fecha4);
            fechas.Add(fecha5);

            bool resultado = IdLogicFunctions.RevisarFechas(fechaInicio, fechaFin, fechas);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarFechas retorne un valor booleano True si las fecha no presentan
          * un traslape.
          */
        [TestMethod]
        public void RevisarFechas_No_Traslape_Test()
        {
            DateTime fechaInicio = new DateTime(2022, 12, 7);
            DateTime fechaFin = new DateTime(2022, 12, 19);

            Fechas fecha1 = new Fechas();
            fecha1.FechaInicio = new DateTime(2021, 1, 10);
            fecha1.FechaFin = new DateTime(2021, 1, 20);

            Fechas fecha2 = new Fechas();
            fecha2.FechaInicio = new DateTime(2021, 5, 27);
            fecha2.FechaFin = new DateTime(2021, 6, 5);

            Fechas fecha3 = new Fechas();
            fecha3.FechaInicio = new DateTime(2021, 11, 2);
            fecha3.FechaFin = new DateTime(2021, 11, 17);

            Fechas fecha4 = new Fechas();
            fecha4.FechaInicio = new DateTime(2021, 12, 26);
            fecha4.FechaFin = new DateTime(2022, 1, 10);

            Fechas fecha5 = new Fechas();
            fecha5.FechaInicio = new DateTime(2022, 7, 13);
            fecha5.FechaFin = new DateTime(2022, 7, 27);

            List<Fechas> fechas = new List<Fechas>();

            fechas.Add(fecha1);
            fechas.Add(fecha2);
            fechas.Add(fecha3);
            fechas.Add(fecha4);
            fechas.Add(fecha5);

            bool resultado = IdLogicFunctions.RevisarFechas(fechaInicio, fechaFin, fechas);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarFechas retorne un valor booleano False si las fecha presentan un
          * traslape.
          */
        [TestMethod]
        public void RevisarFechas_Sí_Traslape_Test()
        {
            DateTime fechaInicio = new DateTime(2021, 1, 15);
            DateTime fechaFin = new DateTime(2021, 1, 29);

            Fechas fecha1 = new Fechas();
            fecha1.FechaInicio = new DateTime(2021, 1, 10);
            fecha1.FechaFin = new DateTime(2021, 1, 20);

            Fechas fecha2 = new Fechas();
            fecha2.FechaInicio = new DateTime(2021, 5, 27);
            fecha2.FechaFin = new DateTime(2021, 6, 5);

            Fechas fecha3 = new Fechas();
            fecha3.FechaInicio = new DateTime(2021, 11, 2);
            fecha3.FechaFin = new DateTime(2021, 11, 17);

            Fechas fecha4 = new Fechas();
            fecha4.FechaInicio = new DateTime(2021, 12, 26);
            fecha4.FechaFin = new DateTime(2022, 1, 10);

            Fechas fecha5 = new Fechas();
            fecha5.FechaInicio = new DateTime(2022, 7, 13);
            fecha5.FechaFin = new DateTime(2022, 7, 27);

            List<Fechas> fechas = new List<Fechas>();

            fechas.Add(fecha1);
            fechas.Add(fecha2);
            fechas.Add(fecha3);
            fechas.Add(fecha4);
            fechas.Add(fecha5);

            bool resultado = IdLogicFunctions.RevisarFechas(fechaInicio, fechaFin, fechas);

            Assert.IsFalse(resultado);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * EncriptarContrasena no sea un valor nulo.
         */
        [TestMethod]
        public void EncriptarContrasena_No_Nulo_Test()
        {
            string contrasena = "especificacion";

            string resultado = IdLogicFunctions.EncriptarContrasena(contrasena);

            Assert.IsNotNull(resultado);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * EncriptarContrasena no sea igual a la contrasena de entrada.
         */
        [TestMethod]
        public void EncriptarContrasena_Contrasena_Diferente_Test()
        {
            string contrasena = "especificacion";

            string resultado = IdLogicFunctions.EncriptarContrasena(contrasena);

            Assert.AreNotEqual(resultado, contrasena);

        }

    }

}
