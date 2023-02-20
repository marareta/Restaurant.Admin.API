using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Proveedor
    {
        private DC.Proveedor data = null;
        public Proveedor()
        {
            this.data = new DC.Proveedor();
        }

        public List<BE.Proveedor> BuscarProveedoresPorNombre(string obj)
        {
            return data.BuscarProveedoresPorNombre(obj);
        }

        public BE.Proveedor ObtenerProveedorPorId(BE.Proveedor obj)
        {
            return data.ObtenerProveedorPorId(obj);
        }

        public BE.Proveedor ObtenerProveedorPorRFC(BE.Proveedor obj)
        {
            return data.ObtenerProveedorPorRFC(obj);
        }

        public BE.Proveedor GuardarProveedor(BE.Proveedor obj)
        {
            BE.Proveedor retorno = data.GuardarProveedor(obj);
            return data.ObtenerProveedorPorRFC(retorno);
        }
    }
}
