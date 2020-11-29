using Biblioteca_web.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Biblioteca_web.Servicios
{
    public class UsuarioServicio : ServicioBase
    {
       
        public async Task<List<UsuarioModel>> GetUsuarios()
        {
            try
            {
                string url = $"{urlBase}usuarios";
                string response = await this.httpClient.GetStringAsync(url);
                List<UsuarioModel> lstUsuarios = JsonConvert.DeserializeObject<List<UsuarioModel>>(response);
                return lstUsuarios;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HttpResponseMessage> InsertarUsuario(UsuarioModel usuarioModel)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync<UsuarioModel>($"{urlBase}usuarios", usuarioModel);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<UsuarioModel> GetUsuario(string id)
        {
            try
            {
                UsuarioModel usuarioModel = new UsuarioModel();
                string usuarioApi = await httpClient.GetStringAsync($"{urlBase}usuarios/{id}");
                usuarioModel = JsonConvert.DeserializeObject<UsuarioModel>(usuarioApi);
                return usuarioModel;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HttpResponseMessage> UpdateUsuario(UsuarioModel usuarioModel)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PutAsJsonAsync<UsuarioModel>($"{urlBase}usuarios/actualizar/{usuarioModel.Id}", usuarioModel);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HttpResponseMessage> DeleteUsuario(string id)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

                UsuarioModel usuarioModel = await GetUsuario(id);

                if (usuarioModel == null)
                {
                    return response;
                }

                response = await httpClient.PutAsJsonAsync<UsuarioModel>($"{urlBase}usuarios/eliminar/{usuarioModel.Id}", usuarioModel);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
