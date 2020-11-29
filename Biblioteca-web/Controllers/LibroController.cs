using Biblioteca_web.Models;
using Biblioteca_web.Servicios;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Biblioteca_web.Controllers
{
    public class LibroController : Controller
    {
        private readonly IConfiguration _configuration;
        private ServicioLibro servicioLibro;
        private readonly IWebHostEnvironment _hostingEnviroment;
        public LibroController(IWebHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            servicioLibro = new ServicioLibro(_configuration);
            _hostingEnviroment = hostEnvironment;
            _configuration = configuration;
        }
        public ActionResult Index()
        {
            var user = HttpContext.Session.GetString("userToken");
            //UserTokenModel userToken =  JsonConvert.DeserializeObject<UserTokenModel>(user);

            if (!string.IsNullOrEmpty(user))
            {
                return View();
            }
           return RedirectToAction("Index", "Cuenta");
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

            foreach (var genero in lstGeneroModel.Result)
            {
                lst.Add(new SelectListItem() { Text = genero.Nombre, Value = genero.Id.ToString() });
            }

            LibroViewModel libroViewModel = new LibroViewModel
            {
                Libro = new LibroModel(),
                ListGeneros = lst//(IEnumerable<SelectListItem>)servicioLibro.GetGeneros().Result
            };

            libroViewModel.Libro.UsuarioID = userToken.UsuarioId;

            return View(libroViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LibroViewModel libroViewModel)
        {
            bool result = false;
            
            if (ModelState.IsValid)
            {
                var libro = HttpContext.Request.Form.Files;
                string rutaPrincipal = _hostingEnviroment.WebRootPath;
                string nombreArchivo = Guid.NewGuid().ToString();
                string repostorioLibros = Path.Combine(rutaPrincipal, @"Libros");
                string extension = Path.GetExtension(libro[0].FileName);

                using (var fileStreams = new FileStream(Path.Combine(repostorioLibros, nombreArchivo + extension), FileMode.Create))
                {
                    libro[0].CopyTo(fileStreams);
                }

                libroViewModel.Libro.Ruta = @"\Libros\" + nombreArchivo + extension;
                result = servicioLibro.InsertarLibro(libroViewModel.Libro);
            }

            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            UserTokenModel userToken = JsonConvert.DeserializeObject<UserTokenModel>(HttpContext.Session.GetString("userToken"));
            var lstGeneroModel = servicioLibro.GetGeneros();
            List<SelectListItem> lst = new List<SelectListItem>();

            foreach (var genero in lstGeneroModel.Result)
            {
                lst.Add(new SelectListItem() { Text = genero.Nombre, Value = genero.Id.ToString() });
            }

            libroViewModel = new LibroViewModel
            {
                Libro = new LibroModel(),
                ListGeneros = lst//(IEnumerable<SelectListItem>)servicioLibro.GetGeneros().Result
            };

            libroViewModel.Libro.UsuarioID = userToken.UsuarioId;
            ViewBag.message = "Ha ocurrido un error inesperado y el libro no pudo ser agregado";

            return View(libroViewModel);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response;

            UserTokenModel userToken = JsonConvert.DeserializeObject<UserTokenModel>(HttpContext.Session.GetString("userToken"));

            if(!string.IsNullOrEmpty(userToken.Token))
            {
                if (ModelState.IsValid)
                {
                    response = await servicioLibro.DeleteLibro(id, userToken.Token);

                    if (response.IsSuccessStatusCode)
                    {
                        return Json(new { success = true, message = "Libro inactivado correctamente" });
                    }
                }
            }
            
            return Json(new { success = false, message = "Error inactivando libro" });
        }
    }
}
