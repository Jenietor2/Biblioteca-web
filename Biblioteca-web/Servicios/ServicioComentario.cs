using Biblioteca_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Biblioteca_web.Servicios
{
    public class ServicioComentario : ServicioBase
    {
        public async Task<bool> EnviarComentario(ComentarioModel comentarioModel)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                 response = await httpClient.PostAsJsonAsync<ComentarioModel>($"{urlBase}comentario", comentarioModel);

                if(response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
