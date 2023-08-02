using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BE = Restaurant.Admin.BusinessEntities;
using BL = Restaurant.Admin.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Admin.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        [Route("GuardarInventario")]
        [HttpPost]
        public BE.Inventario GuardarInventario(BE.Inventario obj)
        {
            BL.Inventario proxy = new BL.Inventario();
            return proxy.GuardarInventario(obj);
        }

        [Route("ObtenerIngredientes")]
        [HttpPost]
        public List<BE.Ingrediente> ObtenerIngredientes()
        {
            BL.Ingrediente proxy = new BL.Ingrediente();
            return proxy.ObtenerIngredientes();
        }
    }
}
