using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Sucursal
    {
        private DC.Sucursal data = null;
        public Sucursal()
        {
            this.data = new DC.Sucursal();
        }

        public BE.Sucursal ObtenerSucursal()
        {
            return data.ObtenerSucursal();
        }

        public List<BE.Sucursal> ObtenerSucursales()
        {
            return data.ObtenerSucursales();
        }
    }
}
