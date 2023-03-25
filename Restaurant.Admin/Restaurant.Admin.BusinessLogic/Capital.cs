using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Capital
    {
        private DC.Capital data = null;
        public Capital()
        {
            this.data = new DC.Capital();
        }

        public BE.Capital GuardarCapital(BE.Capital obj)
        {
            return data.GuardarCapital(obj);
        }

        public List<BE.Capital> ObtenerCapitalPorFecha(BE.ReporteTemplate obj)
        {
            return data.ObtenerCapitalPorFecha(obj);
        }
    }
}
