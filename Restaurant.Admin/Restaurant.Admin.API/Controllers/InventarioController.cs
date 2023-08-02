using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BE = Restaurant.Admin.BusinessEntities;
using BL = Restaurant.Admin.BusinessLogic;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        [Route("GuardarInventario")]
        [HttpPost]
        public BE.Inventario GuardarInventario(BE.Inventario obj)
        {
            BE.Inventario retorno = new BE.Inventario();
            try
            {
                BL.Inventario proxy = new BL.Inventario();
                retorno = proxy.GuardarInventario(obj);
            }
            catch(Exception ex)
            {
                string error = "";
                if(ex.Message != null)
                {
                    error += "Message: " + ex.Message.ToString() + ". ";
                }
                if (ex.Source != null)
                {
                    error += "Source: " + ex.Source.ToString() + ". ";
                }

                BE.Log objLog = new BE.Log { 
                    LogDescripcion = error,
                    Response = "",
                    TipoLog = new BE.TipoLog
                    {
                        Descripcion = "Error"
                    }
                };
                BL.Log dataLog = new BL.Log();
                dataLog.GuardarLog(objLog);
            }

            return retorno;
        }

        [Route("ObtenerIngredientes")]
        [HttpPost]
        public List<BE.Ingrediente> ObtenerIngredientes()
        {
            BL.Ingrediente proxy = new BL.Ingrediente();
            return proxy.ObtenerIngredientes();
        }

        [Route("GuardarTraspaso")]
        [HttpPost]
        public BE.Traspaso GuardarTraspaso(BE.Traspaso obj)
        {
            BL.Traspaso proxy = new BL.Traspaso();
            return proxy.GuardarTraspaso(obj);
        }
    }
}
