using Biblioteca_web.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Controllers
{
    public class UsuarioController : Controller
    {
        private  UsuarioServicio usuarioServicio;

        public UsuarioController()
        {
            usuarioServicio = new UsuarioServicio();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await usuarioServicio.GetUsuarios();

            return Json(new { data = users });
        }
    }
}
