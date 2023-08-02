using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Restaurant.Admin.APIPrueba.Controllers
{
    public class UsuarioController : ApiController
    {
        [Route("ValidaUsuarioLogin")]
        [HttpPost]
        public BE.Usuario ValidaUsuarioLogin(BE.UsuarioCredenciales obj)
        {
            BL.Usuario data = new BL.Usuario();
            return data.ValidaUsuarioLogin(obj);
        }
    }
}
