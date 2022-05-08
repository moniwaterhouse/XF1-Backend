using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Models
{
    public class Campeonato
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Presupuesto { get; set; }
        public DateTime FechaInicio { get; set; }
        public string HoraInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string HoraFin { get; set; }
        public string ReglasPuntuacion { get; set; }
    }
    
    public class Fechas
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

    public class Nombres
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
    
}
