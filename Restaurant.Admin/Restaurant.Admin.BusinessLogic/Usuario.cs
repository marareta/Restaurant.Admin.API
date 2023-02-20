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
