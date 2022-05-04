using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        public int IdCompetencia { get; set; }
        public string Nombre { get; set; }
        public string NombrePais { get; set; }
        public string NombrePista { get; set; }
        public DateTime FechaClasificacion { get; set; }
        public DateTime HoraClasificacion { get; set; }
        public DateTime FechaCarrera { get; set; }
        public DateTime HoraCarrera { get; set; }
        public string Estado { get; set; }
    }
}
