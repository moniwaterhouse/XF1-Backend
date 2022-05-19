using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public string MarcaEscuderia { get; set; }
        public string NombrePiloto1 { get; set; }
        public string NombrePiloto2 { get; set; }
        public string NombrePiloto3 { get; set; }
        public string NombrePiloto4 { get; set; }
        public string NombrePiloto5 { get; set; }
        public int PuntajePublica { get; set; }
        public int Costo { get; set; }

    }
}
