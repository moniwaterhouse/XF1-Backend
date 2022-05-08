using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        public string IdCampeonato { get; set; }
        public string Nombre { get; set; }
        public string NombrePais { get; set; }
        public string NombrePista { get; set; }
        public DateTime FechaInicio { get; set; }
        public string HoraInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string HoraFin { get; set; }
        public string Estado { get; set; }
    }

    public class FechasCarrera
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
