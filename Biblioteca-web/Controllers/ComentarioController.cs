using Biblioteca_web.Models;
using Biblioteca_web.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Controllers
{
    public class ComentarioController : Controller
    {
        private ServicioComentario servicioComentario;
        public ComentarioController()
        {
             servicioComentario = new ServicioComentario();
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Crear(ComentarioModel comentarioModel)
        {
            if(ModelState.IsValid)
            {
                bool result = false;
                result = await servicioComentario.EnviarComentario(comentarioModel);

               if(result)
                {
                    return RedirectToAction("Index", "Libro");
                }
            }

            ViewBag.message = "Ha ocurrido un error inesperado y no fue posible recibir tu comentario";
            return View(comentarioModel);
        }
    }
}
