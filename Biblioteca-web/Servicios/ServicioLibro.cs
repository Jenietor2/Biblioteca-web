using Biblioteca_web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Servicios
{
    public class ServicioLibro : ServicioBase
    {
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
                string response =  await this.httpClient.GetStringAsync(url);
                List<GeneroModel> lstGeneros = JsonConvert.DeserializeObject<List<GeneroModel>>(response);
                return lstGeneros;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
