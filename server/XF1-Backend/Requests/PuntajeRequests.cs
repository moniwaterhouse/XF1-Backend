using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XF1_Backend.Requests
{
    public class PuntajeRequests
    {
        // actualizar precio de piloto
        public static System.FormattableString UpdatePrecioPiloto(string piloto, int precio) { return $@"EXECUTE sp_actualizar_precio_piloto {piloto}, {precio}"; }
    }
}
