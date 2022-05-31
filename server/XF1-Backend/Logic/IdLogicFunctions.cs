using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using XF1_Backend.Models;
using XF1_Backend.Requests;

namespace XF1_Backend.Logic
{
    public class IdLogicFunctions
    {

        /*
         * Descripción: esta funcion carga un nuevo identificador para cualquier tabla que necesite
         * un identificador numerico entero basado en los id que ya existen.
         * Input: carreras -> es una lista de las carreras existentes.
         * Output: newId -> un entero correspondiente al nuevo id.
         */
        public static int GenerarId(IEnumerable<Id> ids)
        {
            int newId = 1;

            foreach (var id in ids)
            {
                if (id.IdNum >= newId) newId = id.IdNum + 1;
            }

            return newId;

        }

        /*
         * Descripción: esta funcion genera una nueva llave de 6 caracteres alfanumericos
         * para diferenciar las carreras entre sí. La idea es que este no se repita con
         * llaves ya existentes.
         */

        public static string GenerarLlave(IEnumerable<Campeonato> campeonatos)
        {
            Random rd = new Random();
            string possibleCharacters = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";

            string key = "";
            int rand_num;

            for (int i = 0; i < 6; i++)
            {
                rand_num = rd.Next(0, 35);
                key += possibleCharacters[rand_num];
            }

            foreach (var campeonato in campeonatos)
            {
                if (campeonato.Id == key) return GenerarLlave(campeonatos);
            }

            return key;
        }

    }
}