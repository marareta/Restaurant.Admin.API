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
            retorno.Ventas2 = data.ObtenerVentasPorFechas(obj); //Listado de ventas
            retorno.Ventas3 = data.ObtenerVentasPorTipoVenta(obj); //Ventas por tipo de venta (Rappi, Diddi, etc)
            retorno.Ventas4 = data.ObtenerVentasTotalesPorDiaSemana(obj); //Ventas Totales por día de semana
            retorno.DatoEntero1 = obj.DatoEntero1;
            retorno.Productos1 = data.ObtenerReporteVentasProductosMasVendidos(obj);
            retorno.Productos2 = data.ObtenerReporteVentasProductosMenosVendidos(obj);
            retorno.Productos3 = data.ObtenerReporteVentasProductosVendidos(obj);
            retorno.FormasPago1 = data.ObtenerReporteVentasFormasPago(obj);

            return retorno;
        }
    }
}
