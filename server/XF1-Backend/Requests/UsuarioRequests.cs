﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Requests
{
    /*
     * Esta clase contiene los requests relacionados a los datos de los usuarios
     */
    public class UsuarioRequests
    {
        // Obtener todos los correos
        public static string getCorreos = "SELECT Correo FROM USUARIO";

        // Obtener todos los nombres de escuderias
        public static string getEscuderias = "SELECT NombreEscuderia FROM USUARIO";

    }
}
