using Biblioteca_web.Models;
using Biblioteca_web.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Controllers
{
    public class CuentaController : Controller
    {
        private CuentaServicio cuentaServicio;
        public CuentaController()
        {
            cuentaServicio = new CuentaServicio();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioFullModel usuarioFullModel)
        {
            if(ModelState.IsValid)
            {
               var userToken = await cuentaServicio.Login(usuarioFullModel.UsuarioLogin);

                HttpContext.Session.SetString("userToken", userToken);

                if (userToken != null)
                {
                   return RedirectToAction("Index", "Libro");
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
