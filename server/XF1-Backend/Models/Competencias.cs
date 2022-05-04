using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Models
{
    public class Competencias
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public DateTime HoraFinal { get; set; }
        public string ReglasPuntuacion { get; set; }
    }
}
