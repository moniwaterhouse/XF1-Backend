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

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * LongitudNombre no sea un valor nulo.
         */
        [TestMethod]
        public void LongitudNombre_NoNulo_Test()
        {
            string nombre = "especificacion";

            bool resultado = StringLogicFunctions.LongitudNombre(nombre);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudNombre retorne un valor booleano True si el nombre es de 5 a 30
          * caracteres.
          */
        [TestMethod]
        public void LongitudNombre_LongitudCorrecta_Test()
        {
            string nombre = "especificacion";

            bool resultado = StringLogicFunctions.LongitudNombre(nombre);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudNombre retorne un valor booleano False si el nombre es menor de
          * 5 caracteres.
          */
        [TestMethod]
        public void LongitudNombre_LongitudIncorrectaMenor_Test()
        {            
            string nombre = "abc";

            bool resultado = StringLogicFunctions.LongitudNombre(nombre);

            Assert.IsFalse(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudNombre retorne un valor booleano False si el nombre es mayor de
          * 30 caracteres.
          */
        [TestMethod]
        public void LongitudNombre_LongitudIncorrectaMayor_Test()
        {
            string nombre = "qwertyuiopasdfghjklzxcvbnm0123456789";

            bool resultado = StringLogicFunctions.LongitudNombre(nombre);

            Assert.IsFalse(resultado);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * LongitudDescripcionCampeonato no sea un valor nulo.
         */
        [TestMethod]
        public void LongitudDescripcionCampeonato_NoNulo_Test()
        {
            string descripcion = "Campeonato 2022";

            bool resultado = StringLogicFunctions.LongitudDescripcionCampeonato(descripcion);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudDescripcionCampeonato retorne un valor booleano True si la
          * descripcion es menor de 1000 caracteres.
          */
        [TestMethod]
        public void LongitudDescripcionCampeonato_LongitudCorrecta_Test()
        {   
            string descripcion = "La anchura total del monoplaza, excluyendo los neumáticos," +
                                 "no puede ser mayor a 2000 mm. No hay límite de longitud." +
                                 "Las demás normas establecen límites indirectos sobre casi" +
                                 "todas las dimensiones, por lo que casi todos los aspectos del" +
                                 "coche llevan regulaciones de talla. En consecuencia, los" +
                                 "distintos coches tienden a estar muy cerca del mismo tamaño.";

            bool resultado = StringLogicFunctions.LongitudDescripcionCampeonato(descripcion);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudDescripcionCampeonato retorne un valor booleano False si la
          * descripción es mayor de 1000 caracteres.
          */
        [TestMethod]
        public void LongitudDescripcionCampeonato_LongitudIncorrecta_Test()
        {
            string descripcion = "La anchura total del monoplaza, excluyendo los neumáticos," +
                                 "no puede ser mayor a 2000 mm. No hay límite de longitud." +
                                 "Las demás normas establecen límites indirectos sobre casi" +
                                 "todas las dimensiones, por lo que casi todos los aspectos del" +
                                 "coche llevan regulaciones de talla. En consecuencia, los" +
                                 "distintos coches tienden a estar muy cerca del mismo tamaño." +
                                 "Desde 2022, el peso total del monoplaza con neumáticos de seco" +
                                 "y con el piloto dentro usando la indumentaria completa, no" +
                                 "puede ser menor a 798 kg en todo momento durante un evento." +
                                 "El coche debe tener cuatro ruedas montadas externamente del" +
                                 "chasis. Las de la parte anterior son las únicas que pueden" +
                                 "virar, mientras que las posteriores son las únicas que pueden" +
                                 "tener tracción.Actualmente hay unas distancias mínimas entre" +
                                 "las ruedas y el chasis. El chasis principal contiene una jaula" +
                                 "de seguridad, la cual contiene el puesto de conducción y su" +
                                 "función es reducir el impacto recibido por un posible choque" +
                                 "frontal y lateral, que va desde la parte superior del casco" +
                                 "del piloto y rodea todo el cockpit.El depósito de gasolina" +
                                 "se encuentra justo detrás del puesto de conducción." +
                                 "Adicionalmente, el coche debe tener barras reforzadas delante" +
                                 "y detrás del piloto.El piloto debe ser capaz de entrar y salir" +
                                 "del coche sin más esfuerzo que retirar el volante y el" +
                                 "reposacabezas.";

            bool resultado = StringLogicFunctions.LongitudDescripcionCampeonato(descripcion);

            Assert.IsFalse(resultado);

        }

        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * LongitudNombreUsuario no sea un valor nulo.
         */
        [TestMethod]
        public void LongitudNombreUsuario_NoNulo_Test()
        {
            string nombreUsuario = "DanielMadriz";

            bool resultado = StringLogicFunctions.LongitudNombreUsuario(nombreUsuario);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudNombreUsuario retorne un valor booleano True si el nombre de
          * usuario es de 1 a 30 caracteres.
          */
        [TestMethod]
        public void LongitudNombreUsuario_LongitudCorrecta_Test()
        {
            string nombreUsuario = "DanielMadriz";

            bool resultado = StringLogicFunctions.LongitudNombreUsuario(nombreUsuario);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudNombreUsuario retorne un valor booleano False si el nombre de
          * usuario es menor de 1 caracter.
          */
        [TestMethod]
        public void LongitudNombreUsuario_LongitudIncorrectaMenor_Test()
        {
            string nombreUsuario = "";

            bool resultado = StringLogicFunctions.LongitudNombreUsuario(nombreUsuario);

            Assert.IsFalse(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudNombreUsuario retorne un valor booleano False si el nombre de
          * usuario es mayor de 30 caracteres.
          */
        [TestMethod]
        public void LongitudNombreUsuario_LongitudIncorrectaMayor_Test()
        {
            string nombreUsuario = "DanielEduardoMadrizHuertasEspecificacion2022";

            bool resultado = StringLogicFunctions.LongitudNombreUsuario(nombreUsuario);

            Assert.IsFalse(resultado);

        }







        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * LongitudContrasena no sea un valor nulo.
         */
        [TestMethod]
        public void LongitudContrasena_NoNulo_Test()
        {
            string contrasena = "Espe2022";

            bool resultado = StringLogicFunctions.LongitudContrasena(contrasena);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudContrasena retorne un valor booleano True si la contraseña es
          * de 8 caracteres alfanuméricos.
          */
        [TestMethod]
        public void LongitudContrasena_8CaracteresAlfanumericos_Test()
        {
            string contrasena = "Espe2022";

            bool resultado = StringLogicFunctions.LongitudContrasena(contrasena);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudContrasena retorne un valor booleano False si la contraseña es
          * menor de 8 caracteres alfanuméricos.
          */
        [TestMethod]
        public void LongitudContrasena_LongitudIncorrectaMenor_Test()
        {
            string contrasena = "Es22";

            bool resultado = StringLogicFunctions.LongitudContrasena(contrasena);

            Assert.IsFalse(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudContrasena retorne un valor booleano False si la contraseña es
          * mayor de 8 caracteres alfanuméricos.
          */
        [TestMethod]
        public void LongitudContrasena_LongitudIncorrectaMayor_Test()
        {
            string contrasena = "Especificacion2022";

            bool resultado = StringLogicFunctions.LongitudContrasena(contrasena);

            Assert.IsFalse(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudContrasena retorne un valor booleano False si la contraseña es
          * de 8 letras.
          */
        [TestMethod]
        public void LongitudContrasena_CaracteresNoAlfanumericosLetras_Test()
        {
            string contrasena = "Usuarios";

            bool resultado = StringLogicFunctions.LongitudContrasena(contrasena);

            Assert.IsFalse(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * LongitudContrasena retorne un valor booleano False si la contraseña es
          * de 8 números.
          */
        [TestMethod]
        public void LongitudContrasena_CaracteresNoAlfanumericosNumeros_Test()
        {
            string contrasena = "12345678";

            bool resultado = StringLogicFunctions.LongitudContrasena(contrasena);

            Assert.IsFalse(resultado);

        }

















        /*
         * Descripción: esta prueba unitaria verifica que la salida de la función
         * RevisarCorreo no sea un valor nulo.
         */
        [TestMethod]
        public void RevisarCorreo_NoNulo_Test()
        {
            string correoUsuario = "daniel.madriz@itcr.ac.cr";

            CorreoUsuario correoUsuario1 = new CorreoUsuario();
            correoUsuario1.Correo = "correoUsuario1@gmail.com";

            CorreoUsuario correoUsuario2 = new CorreoUsuario();
            correoUsuario2.Correo = "correoUsuario2@gmail.com";

            CorreoUsuario correoUsuario3 = new CorreoUsuario();
            correoUsuario3.Correo = "correoUsuario3@gmail.com";

            CorreoUsuario correoUsuario4 = new CorreoUsuario();
            correoUsuario4.Correo = "correoUsuario4@gmail.com";

            CorreoUsuario correoUsuario5 = new CorreoUsuario();
            correoUsuario5.Correo = "correoUsuario5@gmail.com";

            List<CorreoUsuario> correos = new List<CorreoUsuario>();

            correos.Add(correoUsuario1);
            correos.Add(correoUsuario2);
            correos.Add(correoUsuario3);
            correos.Add(correoUsuario4);
            correos.Add(correoUsuario5);

            bool resultado = StringLogicFunctions.RevisarCorreo(correoUsuario, correos);

            Assert.IsNotNull(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarCorreo retorne un valor booleano True si el correo es único.
          */
        [TestMethod]
        public void RevisarCorreo_CorreoUnico_Test()
        {
            string correoUsuario = "daniel.madriz@itcr.ac.cr";

            CorreoUsuario correoUsuario1 = new CorreoUsuario();
            correoUsuario1.Correo = "correoUsuario1@gmail.com";

            CorreoUsuario correoUsuario2 = new CorreoUsuario();
            correoUsuario2.Correo = "correoUsuario2@gmail.com";

            CorreoUsuario correoUsuario3 = new CorreoUsuario();
            correoUsuario3.Correo = "correoUsuario3@gmail.com";

            CorreoUsuario correoUsuario4 = new CorreoUsuario();
            correoUsuario4.Correo = "correoUsuario4@gmail.com";

            CorreoUsuario correoUsuario5 = new CorreoUsuario();
            correoUsuario5.Correo = "correoUsuario5@gmail.com";

            List<CorreoUsuario> correos = new List<CorreoUsuario>();

            correos.Add(correoUsuario1);
            correos.Add(correoUsuario2);
            correos.Add(correoUsuario3);
            correos.Add(correoUsuario4);
            correos.Add(correoUsuario5);

            bool resultado = StringLogicFunctions.RevisarCorreo(correoUsuario, correos);

            Assert.IsTrue(resultado);

        }

        /*
          * Descripción: esta prueba unitaria verifica que la salida de la función
          * RevisarCorreo retorne un valor booleano False si el correo no es único.
          */
        [TestMethod]
        public void RevisarCorreo_CorreoRepetido_Test()
        {
            string correoUsuario = "correoUsuario3@gmail.com";

            CorreoUsuario correoUsuario1 = new CorreoUsuario();
            correoUsuario1.Correo = "correoUsuario1@gmail.com";

            CorreoUsuario correoUsuario2 = new CorreoUsuario();
            correoUsuario2.Correo = "correoUsuario2@gmail.com";

            CorreoUsuario correoUsuario3 = new CorreoUsuario();
            correoUsuario3.Correo = "correoUsuario3@gmail.com";

            CorreoUsuario correoUsuario4 = new CorreoUsuario();
            correoUsuario4.Correo = "correoUsuario4@gmail.com";

            CorreoUsuario correoUsuario5 = new CorreoUsuario();
            correoUsuario5.Correo = "correoUsuario5@gmail.com";

            List<CorreoUsuario> correos = new List<CorreoUsuario>();

            correos.Add(correoUsuario1);
            correos.Add(correoUsuario2);
            correos.Add(correoUsuario3);
            correos.Add(correoUsuario4);
            correos.Add(correoUsuario5);

            bool resultado = StringLogicFunctions.RevisarCorreo(correoUsuario, correos);

            Assert.IsFalse(resultado);

        }

    }
}
