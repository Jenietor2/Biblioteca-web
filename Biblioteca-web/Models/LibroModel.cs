using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Models
{
    public class LibroModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Autor { get; set; }
        public bool Activo { get; set; } = true;
        public int GeneroId { get; set; }
        public GeneroModel Genero { get; set; }
        public string UsuarioID { get; set; }
        public UsuarioModel Usuario { get; set; }
        [Required]
        public string Ruta { get; set; }
    }
}
