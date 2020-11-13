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
    public class UsuarioServicio : IUsuarioServicio
    {
        private  HttpClient httClient;
        //DEBUG
        //private readonly string urlBase = "https://localhost:44380/api/";
        //RELEASE
        private readonly string urlBase = "https://localhost:443/api/";
        public UsuarioServicio()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            httClient = new HttpClient(clientHandler);

        }
        public async Task<List<UsuarioModel>> GetUsuarios()
        {
            try
            {
                string url = $"{urlBase}usuarios";
                string response = await httClient.GetStringAsync(url);
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
                HttpResponseMessage response = await httClient.PostAsJsonAsync<UsuarioModel>($"{urlBase}usuarios", usuarioModel);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<UsuarioModel> GetUsuario(int id)
        {
            try
            {
                UsuarioModel usuarioModel = new UsuarioModel();
                string usuarioApi = await httClient.GetStringAsync($"{urlBase}usuarios/{id}");
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
                HttpResponseMessage response = await httClient.PutAsJsonAsync<UsuarioModel>($"{urlBase}usuarios/actualizar/{usuarioModel.Id}", usuarioModel);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
