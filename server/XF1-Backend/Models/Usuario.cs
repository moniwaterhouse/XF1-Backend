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

    public class UsuarioEquipo
    {
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Pais { get; set; }
        public string Contrasena { get; set; }
        public string NombreEscuderia { get; set; }
        public string MarcaEscuderia_1 { get; set; }
        public string NombrePiloto1_1 { get; set; }
        public string NombrePiloto2_1 { get; set; }
        public string NombrePiloto3_1 { get; set; }
        public string NombrePiloto4_1 { get; set; }
        public string NombrePiloto5_1 { get; set; }
        public int Costo_1 { get; set; }
        public string MarcaEscuderia_2 { get; set; }
        public string NombrePiloto1_2 { get; set; }
        public string NombrePiloto2_2 { get; set; }
        public string NombrePiloto3_2 { get; set; }
        public string NombrePiloto4_2 { get; set; }
        public string NombrePiloto5_2 { get; set; }
        public int Costo_2 { get; set; }

    }

    public class UsuarioPerfil
    {
        public string NombreUsuario { get; set; }
        public string Pais { get; set; }
        public string NombreEscuderia { get; set; }
        public string MarcaEscuderia { get; set; }
        public string NombreEquipo { get; set; }
        public string NombrePiloto1 { get; set; }
        public string NombrePiloto2 { get; set; }
        public string NombrePiloto3 { get; set; }
        public string NombrePiloto4 { get; set; }
        public string NombrePiloto5 { get; set; }
    }
}
