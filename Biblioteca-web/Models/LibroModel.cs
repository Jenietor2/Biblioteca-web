﻿using Microsoft.AspNetCore.Http;
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
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(120)]
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Autor { get; set; }
        public bool Activo { get; set; } = true;
        [Display(Name = "Genero")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int GeneroId { get; set; }
        public GeneroModel Genero { get; set; }
        public string UsuarioID { get; set; }
        public UsuarioModel Usuario { get; set; }
        public string Ruta { get; set; }
        public IFormFileCollection Libro { get; set; }
    }
}
