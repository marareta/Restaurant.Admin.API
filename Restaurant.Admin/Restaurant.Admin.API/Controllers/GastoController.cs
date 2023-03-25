using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BE = Restaurant.Admin.BusinessEntities;
using BL = Restaurant.Admin.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        [Route("GuardarGasto")]
        [HttpPost]
        public BE.Gasto GuardarGasto(BE.Gasto obj)
        {
            BL.Gasto proxy = new BL.Gasto();
            return proxy.GuardarGasto(obj);
        }

        [Route("ObtenerGastosPorFecha")]
        [HttpPost]
        public List<BE.Gasto> ObtenerGastosPorFecha(BE.ReporteTemplate obj)
        {
            BL.Gasto proxy = new BL.Gasto();
            return proxy.ObtenerGastosPorFecha(obj);
        }
    }
}
