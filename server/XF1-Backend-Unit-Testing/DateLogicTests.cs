using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using XF1_Backend.Logic;
using XF1_Backend.Models;
using System;

namespace XF1_Backend_Unit_Testing
{
    [TestClass]
    public class DateLogicTests
    {
        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarTraslapeFechas no sea un valor nulo.
          */
        [TestMethod]
        public void RevisarTraslapeFechas_NoNulo_Test()
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

            bool resultado = DateLogicFunctions.RevisarTraslapeFechas(fechaInicio, fechaFin, fechas);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarTraslapeFechas retorne un valor booleano True si las fechas no presentan
          * un traslape.
          */
        [TestMethod]
        public void RevisarTraslapeFechas_NoTraslape_Test()
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

            bool resultado = DateLogicFunctions.RevisarTraslapeFechas(fechaInicio, fechaFin, fechas);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarTraslapeFechas retorne un valor booleano False si las fechas presentan
          * un traslape.
          */
        [TestMethod]
        public void RevisarTraslapeFechas_SiTraslape_Test()
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

            bool resultado = DateLogicFunctions.RevisarTraslapeFechas(fechaInicio, fechaFin, fechas);

            Assert.IsFalse(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarFechasAnteriores no sea un valor nulo.
          */
        [TestMethod]
        public void RevisarFechasAnteriores_NoNulo_Test()
        {
            DateTime fechaInicio = new DateTime(2022, 12, 7);
            DateTime fechaFin = new DateTime(2022, 12, 19);

            bool resultado = DateLogicFunctions.RevisarFechasAnteriores(fechaInicio, fechaFin);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarFechasAnteriores retorne un valor booleano True si las fechas no
          * son anteriores a la actual.
          */
        [TestMethod]
        public void RevisarFechasAnteriores_NoAnteriores_Test()
        {
            DateTime fechaInicio = new DateTime(2022, 12, 7);
            DateTime fechaFin = new DateTime(2022, 12, 19);

            bool resultado = DateLogicFunctions.RevisarFechasAnteriores(fechaInicio, fechaFin);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarFechasAnteriores retorne un valor booleano False si las fechas
          * son anteriores a la actual.
          */
        [TestMethod]
        public void RevisarFechasAnteriores_SiAnteriores_Test()
        {
            DateTime fechaInicio = new DateTime(2020, 4, 25);
            DateTime fechaFin = new DateTime(2020, 5, 9);

            bool resultado = DateLogicFunctions.RevisarFechasAnteriores(fechaInicio, fechaFin);

            Assert.IsFalse(resultado);

        }

    }

}
