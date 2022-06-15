using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using XF1_Backend.Logic;
using XF1_Backend.Models;
using XF1_Backend.Repositories;

namespace XF1_Backend.Services
{
    public class UsuarioService : ControllerBase
    {
        public ObjectResult NullValidations(Usuario usuario)
        {
            bool permitido = NullValuesLogicFunctions.ValoresNulosUsuario(usuario);
            if (permitido == false) return StatusCode(409, "Se requieren todos los datos del usuario");

            return StatusCode(200, "ok");
        }

        public ObjectResult StringValidations(Usuario usuario)
        {
            // revisión de la longitud del nombre de usuario
            bool permitido = StringLogicFunctions.LongitudNombre(usuario.NombreUsuario);
            if (permitido == false) return StatusCode(409, "El nombre de usuario debe ser de 1 a 30 caracteres");

            // revisión de la longitud de la contraseña
            permitido = StringLogicFunctions.LongitudContrasena(usuario.Contrasena);
            if (permitido == false) return StatusCode(409, "La contraseña del usuario debe ser de 8 caracteres alfanuméricos");

            return StatusCode(200, "ok");
        }

        public ObjectResult UniquenessValidations(Usuario usuario, UsuarioRepository repo)
        {
            // revisión de repetición de correo
            IEnumerable<CorreoUsuario> correos = repo.GetCorreos();
            bool permitido = StringLogicFunctions.RevisarCorreo(usuario.Correo, correos);
            if (permitido == false) return StatusCode(409, "El correo ya ha sido registrado");

            return StatusCode(200, "ok");
        }
    }
}
