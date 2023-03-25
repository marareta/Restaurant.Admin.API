using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Usuario
    {
        private readonly DC.Usuario data = null;
        public Usuario()
        {
            this.data = new DC.Usuario();
        }

        public BE.UsuarioCredenciales ValidarUsuarioExistente(BE.Usuario usuario)
        {
            return data.ValidarUsuarioExistente(usuario);
        }

        public List<BE.Usuario> ObtenerUsuariosBusqueda(BE.UsuarioCredenciales obj)
        {
            BusinessLogic.Modulo dataM = new BusinessLogic.Modulo();
            List<BE.Usuario> retorno = data.ObtenerUsuariosBusqueda(obj);
            foreach(var usu in retorno)
            {
                usu.UsuarioSucursales = data.ObtenerUsuariosSucursales(usu);
                usu.UsuarioSubModulos = dataM.ObtenerSubModulosPorUsuario(usu);
            }
            return retorno;
        }

        public BE.Usuario GuardarUsuario(BE.Usuario obj)
        {
            BE.Usuario retorno = data.GuardarUsuario(obj);
            data.EliminaUsuarioSucursal(obj);
            foreach(var usuS in obj.UsuarioSucursales)
            {
                data.GuardaUsuarioSucursal(usuS, retorno);
            }

            return retorno;
        }

        public List<BE.Usuario> ObtenerUsuariosParaSincronizacionConSucursal(BE.Sucursal obj)
        {
            List<BE.Usuario> retorno = data.ObtenerUsuariosParaSincronizacionConSucursal(obj);
            BusinessLogic.Modulo dataM = new Modulo();

            foreach(var usu in retorno)
            {
                usu.UsuarioSubModulos = dataM.ObtenerSubModulosPorUsuario(usu);
            }

            return retorno;
        }

        public BE.UsuarioCredenciales ValidaUsuarioPassword(BE.UsuarioCredenciales credenciales)
        {
            return data.ValidaUsuarioPassword(credenciales);
        }

        
        public BE.Usuario ValidaUsuarioLogin(BE.UsuarioCredenciales credenciales)
        {
            DC.Modulo dataM = new DC.Modulo();
            BE.Usuario obj = data.ValidaUsuarioLogin(credenciales);
            if (obj != null)
            {
                obj.UsuarioDatosGenerales = data.ObtenerUsuarioDatosGenerales(obj);
                obj.UsuarioSubModulos = dataM.ObtenerSubModulosPorUsuario(obj);



                ////Serializamos el objeto usuario para guardarlo en TOKEN
                //XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                //using (StringWriter textWriter = new StringWriter())
                //{
                //    xmlSerializer.Serialize(textWriter, obj);
                //    obj.Token = textWriter.ToString();
                //}
            }
            return obj;
        }

        public BE.UsuarioDatosGenerales ObtenerUsuarioDatosGenerales(BE.Usuario obj)
        {
            return data.ObtenerUsuarioDatosGenerales(obj);
        }

        public string ValidarUsuarioEstatusLogin(BE.Usuario usuario)
        {
            return data.ValidarUsuarioEstatusLogin(usuario);
        }
    }
}
