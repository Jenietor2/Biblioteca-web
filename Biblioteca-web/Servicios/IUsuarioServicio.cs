using Biblioteca_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Servicios
{
    public interface IUsuarioServicio
    {
        Task<List<UsuarioModel>> GetUsuarios();
    }
}
