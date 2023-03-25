using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Modulo
    {
        private DC.Modulo data = null;
        public Modulo()
        {
            this.data = new DC.Modulo();
        }

        public List<BE.UsuarioSubModulo> ObtenerSubModulosPorUsuario(BE.Usuario obj)
        {
            return data.ObtenerSubModulosPorUsuario(obj);
        }

        public List<BE.Modulo> ObtenerUsuarioSubModulos(BE.Usuario usuario)
        {
            List<BE.Modulo> retorno = data.ObtenerModulos();
            foreach (var modulo in retorno)
            {
                modulo.SubModulos = data.ObtenerSubModulosPorUsuario(modulo, usuario);
            }

            return retorno;
        }

        public List<BE.Modulo> ObtenerModulos()
        {
            List<BE.Modulo> retorno = data.ObtenerModulos();
            foreach (var modulo in retorno)
            {
                modulo.SubModulos = data.ObtenerSubModulos(modulo);
            }

            return retorno;
        }

        public void GuardarUsuarioSubModulo(BE.UsuarioSubModulo obj)
        {
            data.GuardarUsuarioSubModulo(obj);
        }
    }
}
