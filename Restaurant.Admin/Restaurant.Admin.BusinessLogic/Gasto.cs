using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Gasto
    {
        private DC.Gasto data = null;
        public Gasto()
        {
            this.data = new DC.Gasto();
        }

        public BE.Gasto GuardarGasto(BE.Gasto obj)
        {
            return data.GuardarGasto(obj);
        }

        public List<BE.Gasto> ObtenerGastosPorFecha(BE.ReporteTemplate obj)
        {
            return data.ObtenerGastosPorFecha(obj);
        }
    }
}
