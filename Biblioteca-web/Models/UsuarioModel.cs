using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Models
{
    public class UsuarioModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(80)]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(80)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(18)]
        [Display(Name = "No documento")]
        public string NumeroDocumento { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(80)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(80)]
        //[RegularExpression(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}\b", ErrorMessage = "No es un correo valido")]
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public List<LibroModel> Libros { get; set; }
    }
}
