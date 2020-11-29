using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Models
{
    public class UsuarioLoginModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression("^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$", ErrorMessage = "No es un correo valido")]
        public string Email { get; set; }
        [Required (ErrorMessage = "El campo {0} es requerido")]
        public string Password { get; set; }
    }
}
