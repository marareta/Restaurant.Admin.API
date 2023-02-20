using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class SubCuenta
    {
        private DC.SubCuenta data = null;
        public SubCuenta()
        {
            this.data = new DC.SubCuenta();
        }

        public List<BE.SubCuenta> ObtenerSubCuentasPorCuenta(BE.Cuenta obj)
        {
            return data.ObtenerSubCuentasPorCuenta(obj);
        }

        public List<BE.SubCuentaFinal> ObtenerSubCuentasFinalesPorSubCuenta(BE.SubCuenta obj)
        {
            return data.ObtenerSubCuentasFinalesPorSubCuenta(obj);
        }
    }
}
