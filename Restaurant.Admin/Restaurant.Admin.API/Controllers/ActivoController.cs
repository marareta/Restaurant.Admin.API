using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BE = Restaurant.Admin.BusinessEntities;
using BL = Restaurant.Admin.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivoController : ControllerBase
    {
        [Route("GuardarActivo")]
        [HttpPost]
        public BE.Activo GuardarActivo(BE.Activo obj)
        {
            BL.Activo proxy = new BL.Activo();
            return proxy.GuardarActivo(obj);
        }

        [Route("ObtenerActivosPorFecha")]
        [HttpPost]
        public List<BE.Activo> ObtenerActivosPorFecha(BE.ReporteTemplate obj)
        {
            BL.Activo proxy = new BL.Activo();
            return proxy.ObtenerActivosPorFecha(obj);
        }
    }
}
