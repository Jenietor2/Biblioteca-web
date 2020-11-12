using Biblioteca_web.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Biblioteca_web.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private  HttpClient httClient;
        private readonly string urlBase = "http://localhost:8090/api/";
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
    }
}
