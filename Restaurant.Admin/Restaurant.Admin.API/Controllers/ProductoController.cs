using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BE = Restaurant.Admin.BusinessEntities;
using BL = Restaurant.Admin.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [Route("ObtenerProductos")]
        [HttpPost]
        public List<BE.Producto> ObtenerProductos()
        {
            BL.Producto proxy = new BL.Producto();
            return proxy.ObtenerProductos();
        }

        [Route("ObtenerProductoPorId")]
        [HttpPost]
        public BE.Producto ObtenerProductoPorId(BE.Producto obj)
        {
            BL.Producto proxy = new BL.Producto();
            return proxy.ObtenerProductoPorId(obj);
        }

        [Route("GuardarProductoIngredientes")]
        [HttpPost]
        public BE.Producto GuardarProductoIngredientes(BE.Producto obj)
        {
            BL.Producto proxy = new BL.Producto();
            return proxy.GuardarProductoIngredientes(obj);
        }
    }
}
