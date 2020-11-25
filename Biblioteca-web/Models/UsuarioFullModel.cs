using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Models
{
    public class UsuarioFullModel
    {
        public UsuarioModel Usuario { get; set; }
        public UsuarioLoginModel UsuarioLogin { get; set; }
    }
}
