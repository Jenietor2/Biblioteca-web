using Biblioteca_web.Models;
using Biblioteca_web.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Biblioteca_web.Controllers
{
    
    public class GeneroController : Controller
    {
        private ServicioGenero servicioGenero;
        public GeneroController()
        {
            servicioGenero = new ServicioGenero();
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(GeneroModel generoModel)
        {
            if(ModelState.IsValid)
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = await servicioGenero.Create(generoModel);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Libro");
                }
            }
            ViewBag.message = "No fue posible crear el genero";
            return View(generoModel);
        }
    }
}
