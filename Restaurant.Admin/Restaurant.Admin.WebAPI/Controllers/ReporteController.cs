using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BE = Restaurant.Admin.BusinessEntities;
using BL = Restaurant.Admin.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Admin.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        [Route("ObtenerReporteEstadoResultados")]
        [HttpPost]
        public BE.ReporteTemplate ObtenerReporteEstadoResultados(BE.ReporteTemplate obj)
        {
            BL.Reporte proxy = new BL.Reporte();
            return proxy.ObtenerReporteEstadoResultados(obj);
        }

        [Route("ObtenerReporteVentasPorTipo")]
        [HttpPost]
        public BE.ReporteTemplate ObtenerReporteVentasPorTipo(BE.ReporteTemplate obj)
        {
            BL.Reporte proxy = new BL.Reporte();
            return proxy.ObtenerReporteVentasPorTipo(obj);
        }
    }
}
