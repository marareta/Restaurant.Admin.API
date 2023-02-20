using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Reporte
    {
        private DC.Reporte data = null;
        public Reporte()
        {
            this.data = new DC.Reporte();
        }

        public BE.ReporteTemplate ObtenerReporteEstadoResultados(BE.ReporteTemplate obj)
        {
            return data.ObtenerReporteEstadoResultados(obj);
        }

        public BE.ReporteTemplate ObtenerReporteVentasPorTipo(BE.ReporteTemplate obj)
        {
            BE.ReporteTemplate retorno = data.ObtenerReporteVentasPorTipo(obj);
            retorno.DatoEntero1 = obj.DatoEntero1;
            retorno.Productos1 = data.ObtenerReporteVentasProductosMasVendidos(obj);
            retorno.Productos2 = data.ObtenerReporteVentasProductosMenosVendidos(obj);
            retorno.FormasPago1 = data.ObtenerReporteVentasFormasPago(obj);

            return retorno;
        }
    }
}
