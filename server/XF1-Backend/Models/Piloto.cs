using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Models
{
    public class Piloto
    {
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public int Precio { get; set; }
        public string EquipoReal { get; set; }
        public string UrlLogo { get; set; }
    }
}
