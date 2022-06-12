using System;
using XF1_Backend.Models;

namespace XF1_Backend.Logic

{
    public class IntLogicFunctions
    {
        /*
         * Descripcion: esta funcion verifica que una liga privada aún tenga espacio disponible
         * Entradas: instancia de la clase CantidadJugador
         * Salida: booleano que indica si la liga privada tiene espacio disponible
         */
        public static bool CantidadJugadoresLigaPrivada(CantidadJugador cantidadJugador)
        {
            if (cantidadJugador.Cantidad <= 20)
            {
                return true;
            }

            return false;

        }

    }

}
