using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BE = Restaurant.Admin.BusinessEntities;
using BL = Restaurant.Admin.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Admin.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapitalController : ControllerBase
    {
        [Route("GuardarCapital")]
        [HttpPost]
        public BE.Capital GuardarCapital(BE.Capital obj)
        {
            BL.Capital proxy = new BL.Capital();
            return proxy.GuardarCapital(obj);
        }

        [Route("ObtenerCapitalPorFecha")]
        [HttpPost]
        public List<BE.Capital> ObtenerCapitalPorFecha(BE.ReporteTemplate obj)
        {
            BL.Capital proxy = new BL.Capital();
            return proxy.ObtenerCapitalPorFecha(obj);
        }
    }
}
