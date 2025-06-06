﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyParts.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese Nombre Completo")]
        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "Ingrese Correo")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "Ingrese Contraseña")]
        public string? Clave { get; set; }

        [Required(ErrorMessage = "Ingrese Confirmar Contraseña")]
        public string? ConfirmarClave { get; set; }

        public string? Rol { get; set; }

    }

}
