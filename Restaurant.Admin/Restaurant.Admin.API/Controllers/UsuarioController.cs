using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BE = Restaurant.Admin.BusinessEntities;
using BL = Restaurant.Admin.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [Route("ValidaUsuarioPassword")]
        [HttpPost]
        public BE.UsuarioCredenciales ValidaUsuarioPassword(BE.UsuarioCredenciales obj)
        {
            BL.Usuario data = new BL.Usuario();
            return data.ValidaUsuarioPassword(obj);
        }

        [Route("ObtenerUsuariosParaSincronizacionConSucursal")]
        [HttpPost]
        public List<BE.Usuario> ObtenerUsuariosParaSincronizacionConSucursal(BE.Sucursal obj)
        {
            BL.Usuario data = new BL.Usuario();
            return data.ObtenerUsuariosParaSincronizacionConSucursal(obj);
        }

        [Route("ValidarUsuarioExistente")]
        [HttpPost]
        public BE.UsuarioCredenciales ValidarUsuarioExistente(BE.Usuario obj)
        {
            BL.Usuario data = new BL.Usuario();
            return data.ValidarUsuarioExistente(obj);
        }

        [Route("GuardarUsuario")]
        [HttpPost]
        public BE.Usuario GuardarUsuario(BE.Usuario obj)
        {
            BL.Usuario data = new BL.Usuario();
            return data.GuardarUsuario(obj);
        }

        [Route("ObtenerUsuariosBusqueda")]
        [HttpPost]
        public List<BE.Usuario> ObtenerUsuariosBusqueda(BE.UsuarioCredenciales obj)
        {
            BL.Usuario data = new BL.Usuario();
            return data.ObtenerUsuariosBusqueda(obj);
        }


        [Route("ValidaUsuarioLogin")]
        [HttpPost]
        public BE.Usuario ValidaUsuarioLogin(BE.UsuarioCredenciales obj)
        {
            BL.Usuario data = new BL.Usuario();
            return data.ValidaUsuarioLogin(obj);
        }

        [Route("ObtenerUsuarioDatosGenerales")]
        [HttpPost]
        public BE.UsuarioDatosGenerales ObtenerUsuarioDatosGenerales(BE.Usuario obj)
        {
            BL.Usuario data = new BL.Usuario();
            return data.ObtenerUsuarioDatosGenerales(obj);
        }

        [Route("ValidarUsuarioEstatusLogin")]
        [HttpPost]
        public string ValidarUsuarioEstatusLogin(BE.Usuario obj)
        {
            BL.Usuario data = new BL.Usuario();
            return data.ValidarUsuarioEstatusLogin(obj);
        }

        [Route("ObtenerUsuarioSubModulos")]
        [HttpPost]
        public List<BE.Modulo> ObtenerUsuarioSubModulos(BE.Usuario usuario)
        {
            BL.Modulo data = new BL.Modulo();
            return data.ObtenerUsuarioSubModulos(usuario);
        }

        [Route("GuardarUsuarioSubModulo")]
        [HttpPost]
        public void GuardarUsuarioSubModulo(BE.UsuarioSubModulo obj)
        {
            BL.Modulo data = new BL.Modulo();
            data.GuardarUsuarioSubModulo(obj);
        }

        [Route("GuardarUsuarioImagenPerfil")]
        [HttpPost]
        public bool GuardarUsuarioImagenPerfil(BE.UsuarioDatosGenerales usuario)
        {
            BL.CuentaFtp data = new BL.CuentaFtp();
            BE.CuentaFtp cuenta = data.ObtenerCuentaFtp(new BE.CuentaFtp { Nombre = "FTP de imágen de usuario" });

            //Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(usuario.Nombres);

            return data.SubirImagenPorFTP(cuenta, usuario.ApellidoPaterno + ".jpg", imageBytes);
        }

        [Route("ValidarSiExisteImagen")]
        [HttpPost]
        public bool ValidarSiExisteImagen(BE.UsuarioDatosGenerales usuario)
        {
            BL.CuentaFtp data = new BL.CuentaFtp();
            BE.CuentaFtp cuenta = data.ObtenerCuentaFtp(new BE.CuentaFtp { Nombre = "FTP de imágen de usuario" });

            return data.ValidarSiExisteImagen(cuenta, usuario.ApellidoPaterno + ".jpg");
        }
    }
}
