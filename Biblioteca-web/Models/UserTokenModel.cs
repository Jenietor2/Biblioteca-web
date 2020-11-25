using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_web.Models
{
    public class UserTokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RolName { get; set; }
        public string UsuarioId{ get; set; }
    }
}
