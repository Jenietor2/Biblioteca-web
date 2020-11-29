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
            if (ModelState.IsValid)
            {
                var userToken = await cuentaServicio.Login(usuarioFullModel.UsuarioLogin);

                if (!string.IsNullOrEmpty(userToken))
                {
                    HttpContext.Session.SetString("userToken", userToken);

                    return RedirectToAction("Index", "Libro");
                }
            }
            ViewBag.mensaje = "El usuario o la contraseña no son validos";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(UsuarioFullModel usuarioFullModel)
        {
            if (ModelState.IsValid)
            {
                var userToken = await cuentaServicio.CrearUsuario(usuarioFullModel.Usuario);

                if (userToken != null)
                {
                    HttpContext.Session.Remove("userToken");
                    HttpContext.Session.SetString("userToken", userToken);
                    return RedirectToAction("Index", "Libro");
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Cerrar()
        {
            HttpContext.Session.Remove("userToken");

            return RedirectToAction(nameof(Index));
        }
    }
}
