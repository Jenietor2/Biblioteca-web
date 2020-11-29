using Biblioteca_web.Data;
using Biblioteca_web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Biblioteca_web.Servicios
{
    public class ServicioLibro : ServicioBase
    {
        private readonly IConfiguration _configuration;
        public ServicioLibro(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public async Task<LibroModel> GetLibro(int id)
        {
            try
            {
                LibroModel libroModel = new LibroModel();
                string LibroApi = await httpClient.GetStringAsync($"{urlBase}libros/{id}");
                libroModel = JsonConvert.DeserializeObject<LibroModel>(LibroApi);
                return libroModel;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<LibroModel>> GetLibros()
        {
            try
            {
                string url = $"{urlBase}libros";
                string response = await this.httpClient.GetStringAsync(url);
                List<LibroModel> lstUsuarios = JsonConvert.DeserializeObject<List<LibroModel>>(response);
                return lstUsuarios;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<GeneroModel>> GetGeneros()
        {
            try
            {
                string url = $"{urlBase}generos";
                string response = await this.httpClient.GetStringAsync(url);
                List<GeneroModel> lstGeneros = JsonConvert.DeserializeObject<List<GeneroModel>>(response);
                return lstGeneros;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool InsertarLibro(LibroModel libroModel)
        {

            try
            {
                LibroDAL libroDAL = new LibroDAL(_configuration);
                return libroDAL.InsertBook(libroModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HttpResponseMessage> DeleteLibro(int id, string token)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

                LibroModel LibroModel = await GetLibro(id);

                if (LibroModel == null)
                {
                    return response;
                }

                response = await httpClient.PutAsJsonAsync<LibroModel>($"{urlBase}libros/eliminar/{LibroModel.Id}", LibroModel);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
