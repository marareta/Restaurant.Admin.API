using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BE = Restaurant.Admin.BusinessEntities;
using BL = Restaurant.Admin.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostoController : ControllerBase
    {
        [Route("GuardarCosto")]
        [HttpPost]
        public BE.Costo GuardarCosto(BE.Costo obj)
        {
            BL.Costo proxy = new BL.Costo();
            return proxy.GuardarCosto(obj);
        }
    }
}
