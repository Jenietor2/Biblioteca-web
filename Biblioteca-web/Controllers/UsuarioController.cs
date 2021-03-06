﻿using Biblioteca_web.Models;
using Biblioteca_web.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Biblioteca_web.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioServicio usuarioServicio;
        private string rolName;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UsuarioModel usuarioModel)
        {
            HttpResponseMessage response;
            if (ModelState.IsValid)
            {
                response = await usuarioServicio.InsertarUsuario(usuarioModel);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            UsuarioModel usuarioModel = null;
            var user = HttpContext.Session.GetString("userToken");

            if (!string.IsNullOrEmpty(user))
            {
                UserTokenModel userToken = JsonConvert.DeserializeObject<UserTokenModel>(user);
                usuarioModel = await usuarioServicio.GetUsuario(userToken.UsuarioId);
            }

            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsuarioModel usuarioModel)
        {
            HttpResponseMessage response;

            if (ModelState.IsValid)
            {
                response = await usuarioServicio.UpdateUsuario(usuarioModel);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Libro");
                }
            }
            return View(usuarioModel);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response;
                var user = HttpContext.Session.GetString("userToken");

                if (string.IsNullOrEmpty(user))
                {
                    UserTokenModel userToken = JsonConvert.DeserializeObject<UserTokenModel>(user);
                    response = await usuarioServicio.DeleteUsuario(userToken.UsuarioId);

                    if (response.IsSuccessStatusCode)
                    {
                        return Json(new { success = true, message = "Usuario borrado correctamente" });
                    }
                }
            }
            return Json(new { success = false, message = "Error borrando usuario" });
        }
    }
}
