using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BE = Restaurant.Admin.BusinessEntities;
using BL = Restaurant.Admin.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [Route("GuardarVentaMatriz")]
        [HttpPost]
        public List<BE.Venta> GuardarVentaMatriz(List<BE.Venta> lst)
        {
            BL.Venta proxy = new BL.Venta();
            return proxy.GuardarVentas(lst);
        }

        [Route("ObtenerYearsDisponiblesVentas")]
        [HttpPost]
        public List<Int32> ObtenerYearsDisponiblesVentas()
        {
            BL.Venta proxy = new BL.Venta();
            return proxy.ObtenerYearsDisponiblesVentas();
        }
    }
}
