using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Models
{
    public class Puntaje
    {
        public string CodigoXFIA { get; set; }
        public string Constructor_NaN { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Precio { get; set; }
        public int PosicionCalificacion { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string SinCalificarCalificacion { get; set; }
        public string DescalificadoCalificacion { get; set; }
        public int PosicionCarrera { get; set; }
        public string VueltaMasRapida { get; set; }
        public string GanoACompaneroDeEquipo { get; set; }
        public string SinCalificarCarrera { get; set; }
        public string DescalificadoDeCarrera { get; set; }
        public int nuevosPuntos { get; set; }

    }
}
