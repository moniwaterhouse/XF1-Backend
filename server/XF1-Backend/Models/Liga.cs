using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Models
{
    public class Liga
    {
        public int IdLiga { get; set; }
        public string IdCampeonato { get; set; }
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
    }
}
