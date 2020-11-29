using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Biblioteca_web.Servicios
{
    public class ServicioBase
    {
        public HttpClient httpClient { get; set; }
        //DEBUG
        //private readonly string urlBase = "https://localhost:44380/api/";
        //RELEASE
        //public string urlBase = "https://localhost:443/api/";
        public string urlBase { get { return "https://localhost:44380/api/"; } }
        public ServicioBase()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            httpClient = new HttpClient(clientHandler);
        }
    }
}
