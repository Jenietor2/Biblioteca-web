using Biblioteca_web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Biblioteca_web.Servicios
{
    public class CuentaServicio : ServicioBase
    {
        public async Task<HttpResponseMessage> CrearCuenta(UsuarioModel usuarioModel)
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

        public async Task<string> Login(UsuarioLoginModel usuarioLoginModel)
        {
            try
            {
                HttpResponseMessage respuesta = await httpClient.PostAsJsonAsync<UsuarioLoginModel>($"{urlBase}cuentas/login", usuarioLoginModel);
                
                if(respuesta.IsSuccessStatusCode)
                {
                    string userTokeSerialice = respuesta.Content.ReadAsStringAsync().Result;
                    UserTokenModel userToken = JsonConvert.DeserializeObject<UserTokenModel>(userTokeSerialice);

                    return userTokeSerialice;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
