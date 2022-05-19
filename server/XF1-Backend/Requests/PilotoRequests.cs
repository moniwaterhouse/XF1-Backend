using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Requests
{
    /*
     * Esta clase contiene los requests relacionados a los pilotos
     */
    public class PilotoRequests
    {
        // Obtener todos los pilotos
        public static string GetPilotos = "SELECT * FROM PILOTO";
    }
}
