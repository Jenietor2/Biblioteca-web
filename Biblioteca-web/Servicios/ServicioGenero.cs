using Biblioteca_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Biblioteca_web.Servicios
{
    public class ServicioGenero : ServicioBase
    {
        public async Task<HttpResponseMessage> Create(GeneroModel generoModel)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

                return response = await httpClient.PostAsJsonAsync<GeneroModel>($"{urlBase}generos", generoModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
