﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Models
{
    public class Liga
    {
        public string IdLiga { get; set; }
        public string IdCampeonato { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Activa { get; set; }
    }

    public class PuntajesPublica
    {
        public Int64 Posicion { get; set; }
        public string Jugador { get; set; }
        public string Escuderia { get; set; }
        public string Equipo { get; set; }
        public int Puntos { get; set; }
        public string Correo { get; set; }
    }

    public class InfoLigaPrivada
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string IdLiga { get; set; }
        public int Activa { get; set; }
    }

    public class UsuariosLiga
    {
        public string Jugador { get; set; }
    }

    public class CantidadJugador
    {
        public int Cantidad { get; set; }
    }

    public class IdPrivadas
    {
        public string Id { get; set; }
    }

    public class NuevaLiga
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
    }

    public class ActualizarLiga
    {
        public string Id { get; set; }
        public string Correo { get; set; }
    }
}
