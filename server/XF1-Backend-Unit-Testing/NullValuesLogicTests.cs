using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using XF1_Backend.Logic;
using XF1_Backend.Models;
using System;

namespace XF1_Backend_Unit_Testing
{
    [TestClass]
    public class NullValuesLogicTests
    {
        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * ValoresNulosCampeonato no sea un valor nulo.
         */
        [TestMethod]
        public void ValoresNulosCampeonato_NoNulo_Test()
        {
            Campeonato campeonato = new Campeonato();

            campeonato.Id = "KL9HY6";
            campeonato.Nombre = "Campeonato 2022";
            campeonato.Presupuesto = 2;
            campeonato.FechaInicio = new DateTime(2022, 12, 7);
            campeonato.HoraInicio = "13:00";
            campeonato.FechaFin = new DateTime(2022, 12, 19);
            campeonato.HoraFin = "14:30";

            bool resultado = NullValuesLogicFunctions.ValoresNulosCampeonato(campeonato);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * ValoresNulosCampeonato retorne un valor booleano True si se disponen de
          * todos los datos del campeonato.
          */
        [TestMethod]
        public void ValoresNulosCampeonato_NoFaltanDatos_Test()
        {
            Campeonato campeonato = new Campeonato();

            campeonato.Id = "KL9HY6";
            campeonato.Nombre = "Campeonato 2022";
            campeonato.Presupuesto = 2;
            campeonato.FechaInicio = new DateTime(2022, 12, 7);
            campeonato.HoraInicio = "13:00";
            campeonato.FechaFin = new DateTime(2022, 12, 19);
            campeonato.HoraFin = "14:30";

            bool resultado = NullValuesLogicFunctions.ValoresNulosCampeonato(campeonato);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * ValoresNulosCampeonato retorne un valor booleano False si no se disponen
          * de todos los datos del campeonato.
          */
        [TestMethod]
        public void ValoresNulosCampeonato_SiFaltanDatos_Test()
        {
            Campeonato campeonato = new Campeonato();

            campeonato.Id = "KL9HY6";
            campeonato.Nombre = null;
            campeonato.Presupuesto = 2;
            campeonato.FechaInicio = new DateTime(2022, 12, 7);
            campeonato.HoraInicio = null;
            campeonato.FechaFin = new DateTime(2022, 12, 19);
            campeonato.HoraFin = null;

            bool resultado = NullValuesLogicFunctions.ValoresNulosCampeonato(campeonato);

            Assert.IsFalse(resultado);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * ValoresNulosCarrera no sea un valor nulo.
         */
        [TestMethod]
        public void ValoresNulosCarrera_NoNulo_Test()
        {
            Carrera carrera = new Carrera();

            carrera.Id = 1;
            carrera.IdCampeonato = "KL9HY6";
            carrera.Nombre = "Carrera marzo CRI";
            carrera.NombrePais = "Costa Rica";
            carrera.NombrePista = "Pista San José";
            carrera.FechaInicio = new DateTime(2022, 12, 7);
            carrera.HoraInicio = "13:00";
            carrera.FechaFin = new DateTime(2022, 12, 19);
            carrera.HoraFin = "14:30";
            carrera.Estado = "Carrera Completada";

            bool resultado = NullValuesLogicFunctions.ValoresNulosCarrera(carrera);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * ValoresNulosCarrera retorne un valor booleano True si se disponen de
          * todos los datos de la carrera.
          */
        [TestMethod]
        public void ValoresNulosCarrera_NoFaltanDatos_Test()
        {
            Carrera carrera = new Carrera();

            carrera.Id = 1;
            carrera.IdCampeonato = "KL9HY6";
            carrera.Nombre = "Carrera marzo CRI";
            carrera.NombrePais = "Costa Rica";
            carrera.NombrePista = "Pista San José";
            carrera.FechaInicio = new DateTime(2022, 12, 7);
            carrera.HoraInicio = "13:00";
            carrera.FechaFin = new DateTime(2022, 12, 19);
            carrera.HoraFin = "14:30";
            carrera.Estado = "Carrera Completada";

            bool resultado = NullValuesLogicFunctions.ValoresNulosCarrera(carrera);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * ValoresNulosCarrera retorne un valor booleano False si no se disponen
          * de todos los datos de la carrera.
          */
        [TestMethod]
        public void ValoresNulosCarrera_SiFaltanDatos_Test()
        {
            Carrera carrera = new Carrera();

            carrera.Id = 1;
            carrera.IdCampeonato = null;
            carrera.Nombre = "Carrera marzo CRI";
            carrera.NombrePais = "Costa Rica";
            carrera.NombrePista = null;
            carrera.FechaInicio = new DateTime(2022, 12, 7);
            carrera.HoraInicio = "13:00";
            carrera.FechaFin = new DateTime(2022, 12, 19);
            carrera.HoraFin = "14:30";
            carrera.Estado = null;

            bool resultado = NullValuesLogicFunctions.ValoresNulosCarrera(carrera);

            Assert.IsFalse(resultado);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * ValoresNulosUsuario no sea un valor nulo.
         */
        [TestMethod]
        public void ValoresNulosUsuario_NoNulo_Test()
        {   
            Usuario usuario = new Usuario();

            usuario.NombreUsuario = "DanielMadriz";
            usuario.Correo = "daniel.madriz@itcr.ac.cr";
            usuario.Pais = "Costa Rica";
            usuario.Contrasena = "Espe2022";
            usuario.NombreEscuderia = "Ferrari";
            usuario.IdEquipo1 = 1;
            usuario.IdEquipo2 = 2;

            bool resultado = NullValuesLogicFunctions.ValoresNulosUsuario(usuario);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * ValoresNulosUsuario retorne un valor booleano True si se disponen de
          * todos los datos del usuario.
          */
        [TestMethod]
        public void ValoresNulosUsuario_NoFaltanDatos_Test()
        {
            Usuario usuario = new Usuario();

            usuario.NombreUsuario = "DanielMadriz";
            usuario.Correo = "daniel.madriz@itcr.ac.cr";
            usuario.Pais = "Costa Rica";
            usuario.Contrasena = "Espe2022";
            usuario.NombreEscuderia = "Ferrari";
            usuario.IdEquipo1 = 1;
            usuario.IdEquipo2 = 2;

            bool resultado = NullValuesLogicFunctions.ValoresNulosUsuario(usuario);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * ValoresNulosUsuario retorne un valor booleano False si no se disponen
          * de todos los datos del usuario.
          */
        [TestMethod]
        public void ValoresNulosUsuario_SiFaltanDatos_Test()
        {
            Usuario usuario = new Usuario();

            usuario.NombreUsuario = "DanielMadriz";
            usuario.Correo = null;
            usuario.Pais = "Costa Rica";
            usuario.Contrasena = null;
            usuario.NombreEscuderia = "Ferrari";
            usuario.IdEquipo1 = 1;
            usuario.IdEquipo2 = 2;

            bool resultado = NullValuesLogicFunctions.ValoresNulosUsuario(usuario);

            Assert.IsNotNull(resultado);

            Assert.IsFalse(resultado);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * ValoresNulosEquipo no sea un valor nulo.
         */
        [TestMethod]
        public void VValoresNulosEquipo_NoNulo_Test()
        {
            Equipo equipo = new Equipo();

            equipo.Id = 1234;
            equipo.MarcaEscuderia = "Ferrari";
            equipo.NombrePiloto1 = "Daniel";
            equipo.NombrePiloto2 = "Steven";
            equipo.NombrePiloto3 = "Jose Ignacio";
            equipo.NombrePiloto4 = "Juan Ignacio";
            equipo.NombrePiloto5 = "Mónica";
            equipo.PuntajePublica = 1000;
            equipo.Costo = 1000;

            bool resultado = NullValuesLogicFunctions.ValoresNulosEquipo(equipo);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * ValoresNulosEquipo retorne un valor booleano True si se disponen de
          * todos los datos del equipo.
          */
        [TestMethod]
        public void ValoresNulosEquipo_NoFaltanDatos_Test()
        {
            Equipo equipo = new Equipo();

            equipo.Id = 1234;
            equipo.MarcaEscuderia = "Ferrari";
            equipo.NombrePiloto1 = "Daniel";
            equipo.NombrePiloto2 = "Steven";
            equipo.NombrePiloto3 = "Jose Ignacio";
            equipo.NombrePiloto4 = "Juan Ignacio";
            equipo.NombrePiloto5 = "Mónica";
            equipo.PuntajePublica = 1000;
            equipo.Costo = 1000;

            bool resultado = NullValuesLogicFunctions.ValoresNulosEquipo(equipo);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * ValoresNulosEquipo retorne un valor booleano False si no se disponen
          * de todos los datos del equipo.
          */
        [TestMethod]
        public void ValoresNulosEquipo_SiFaltanDatos_Test()
        {
            Equipo equipo = new Equipo();

            equipo.Id = 1234;
            equipo.MarcaEscuderia = "Ferrari";
            equipo.NombrePiloto1 = "Daniel";
            equipo.NombrePiloto2 = null;
            equipo.NombrePiloto3 = null;
            equipo.NombrePiloto4 = null;
            equipo.NombrePiloto5 = null;
            equipo.PuntajePublica = 1000;
            equipo.Costo = 1000;

            bool resultado = NullValuesLogicFunctions.ValoresNulosEquipo(equipo);

            Assert.IsFalse(resultado);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * ValoresNulosNuevaLiga no sea un valor nulo.
         */
        [TestMethod]
        public void ValoresNulosNuevaLiga_NoNulo_Test()
        {
            NuevaLiga nuevaLiga = new NuevaLiga();

            nuevaLiga.Nombre = "POP";
            nuevaLiga.Correo = "daniel.madriz@itcr.ac.cr";
            
            bool resultado = NullValuesLogicFunctions.ValoresNulosNuevaLiga(nuevaLiga);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * ValoresNulosNuevaLiga retorne un valor booleano True si se disponen de
          * todos los datos de la nueva liga.
          */
        [TestMethod]
        public void ValoresNulosNuevaLiga_NoFaltanDatos_Test()
        {
            NuevaLiga nuevaLiga = new NuevaLiga();

            nuevaLiga.Nombre = "POP";
            nuevaLiga.Correo = "daniel.madriz@itcr.ac.cr";

            bool resultado = NullValuesLogicFunctions.ValoresNulosNuevaLiga(nuevaLiga);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * ValoresNulosNuevaLiga retorne un valor booleano False si no se disponen
          * de todos los datos de la nueva liga.
          */
        [TestMethod]
        public void ValoresNulosNuevaLiga_SiFaltanDatos_Test()
        {
            Equipo equipo = new Equipo();

            NuevaLiga nuevaLiga = new NuevaLiga();

            nuevaLiga.Nombre = "POP";
            nuevaLiga.Correo = null;

            bool resultado = NullValuesLogicFunctions.ValoresNulosNuevaLiga(nuevaLiga);

            Assert.IsFalse(resultado);

        }

    }

}
