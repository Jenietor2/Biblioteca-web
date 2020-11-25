using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Models
{
    public class LibroViewModel
    {
        public LibroModel Libro { get; set; }
        public IEnumerable<SelectListItem> ListGeneros { get; set; }
    }
}
