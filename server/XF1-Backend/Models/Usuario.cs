using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Models
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Pais { get; set; }
        public string Contrasena { get; set; }
        public string NombreEscuderia { get; set; }
        public int IdEquipo1 { get; set; }
        public int IdEquipo2 { get; set; }
    }

    public class CorreoUsuario
    {
        public string Correo { get; set; }
    }

    public class EscuderiaUsuario
    {
        public string NombreEscuderia { get; set; }
    }
}
