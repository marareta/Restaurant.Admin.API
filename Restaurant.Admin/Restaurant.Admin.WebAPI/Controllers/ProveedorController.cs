using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BE = Restaurant.Admin.BusinessEntities;
using BL = Restaurant.Admin.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Admin.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        [Route("ObtenerProveedorPorRFC")]
        [HttpPost]
        public BE.Proveedor ObtenerProveedorPorRFC(BE.Proveedor obj)
        {
            BL.Proveedor proxy = new BL.Proveedor();
            return proxy.ObtenerProveedorPorRFC(obj);
        }

        [Route("ObtenerProveedorPorId")]
        [HttpPost]
        public BE.Proveedor ObtenerProveedorPorId(BE.Proveedor obj)
        {
            BL.Proveedor data = new BL.Proveedor();
            return data.ObtenerProveedorPorId(obj);
        }

        [Route("BuscarProveedoresPorNombre")]
        [HttpPost]
        public List<BE.Proveedor> BuscarProveedoresPorNombre(BE.Proveedor obj)
        {
            BL.Proveedor data = new BL.Proveedor();
            return data.BuscarProveedoresPorNombre(obj.Nombre);
        }

        [Route("GuardarProveedor")]
        [HttpPost]
        public BE.Proveedor GuardarProveedor(BE.Proveedor obj)
        {
            BL.Proveedor proxy = new BL.Proveedor();
            return proxy.GuardarProveedor(obj);
        }
    }
}
