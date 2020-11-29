using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Models
{
    public class GeneroModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(60)]
        public string Nombre { get; set; }
        public List<LibroModel> Libros { get; set; }
        public bool Activo { get; set; } = true;
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Detalle { get; set; }
    }
}
