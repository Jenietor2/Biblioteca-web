using Biblioteca_web.Models;
using Biblioteca_web.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Controllers
{
    public class LibroController : Controller
    {
        private ServicioLibro servicioLibro;
        public LibroController()
        {
            servicioLibro = new ServicioLibro();
        }
        public ActionResult Index()
        {
            var usuarioToken = HttpContext.Session.GetString("userToken");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var libros = await servicioLibro.GetLibros();

            return Json(new { data = libros });
        }
        [HttpGet]
        public IActionResult Create()
        {
            UserTokenModel userToken = JsonConvert.DeserializeObject<UserTokenModel>(HttpContext.Session.GetString("userToken"));

            var lstGeneroModel = servicioLibro.GetGeneros();
            List<SelectListItem> lst = new List<SelectListItem>();

            foreach(var genero in lstGeneroModel.Result)
            {
                lst.Add(new SelectListItem() { Text = genero.Nombre, Value = genero.Id.ToString() });
            }


            SelectListItem generos = new SelectListItem { 
            
            };

            LibroViewModel libroViewModel = new LibroViewModel {
                Libro = new LibroModel(),
                ListGeneros = lst//(IEnumerable<SelectListItem>)servicioLibro.GetGeneros().Result
            };
            libroViewModel.Libro.UsuarioID = userToken.UsuarioId;
            
            return View(libroViewModel);
        }

    }
}
