using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BE = Restaurant.Admin.BusinessEntities;
using BL = Restaurant.Admin.BusinessLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        [Route("ObtenerSucursal")]
        [HttpPost]
        public BE.Sucursal ObtenerSucursal()
        {
            BL.Sucursal proxy = new BL.Sucursal();
            return proxy.ObtenerSucursal();
        }

        [Route("ObtenerModulos")]
        [HttpPost]
        public List<BE.Modulo> ObtenerModulos()
        {
            BL.Modulo proxy = new BL.Modulo();
            return proxy.ObtenerModulos();
        }

        [Route("ObtenerIngredientePorId")]
        [HttpPost]
        public BE.Ingrediente ObtenerIngredientePorId(BE.Ingrediente obj)
        {
            BL.Ingrediente proxy = new BL.Ingrediente();
            return proxy.ObtenerIngredientePorId(obj);
        }

        [Route("GuardarIngrediente")]
        [HttpPost]
        public BE.Ingrediente GuardarIngrediente(BE.Ingrediente obj)
        {
            BL.Ingrediente proxy = new BL.Ingrediente();
            return proxy.GuardarIngrediente(obj);
        }

        [Route("ObtenerUnidadesActivas")]
        [HttpPost]
        public List<BE.Unidad> ObtenerUnidadesActivas()
        {
            BL.Unidad proxy = new BL.Unidad();
            return proxy.ObtenerUnidadesActivas();
        }

        [Route("ObtenerSubCuentasFinalesPorSubCuenta")]
        [HttpPost]
        public List<BE.SubCuentaFinal> ObtenerSubCuentasFinalesPorSubCuenta(BE.SubCuenta obj)
        {
            BL.SubCuenta proxy = new BL.SubCuenta();
            return proxy.ObtenerSubCuentasFinalesPorSubCuenta(obj);
        }

        [Route("ObtenerSucursales")]
        [HttpPost]
        public List<BE.Sucursal> ObtenerSucursales()
        {
            BL.Sucursal proxy = new BL.Sucursal();
            return proxy.ObtenerSucursales();
        }

        [Route("ObtenerSubCuentasPorCuenta")]
        [HttpPost]
        public List<BE.SubCuenta> ObtenerSubCuentasPorCuenta(BE.Cuenta obj)
        {
            BL.SubCuenta proxy = new BL.SubCuenta();
            return proxy.ObtenerSubCuentasPorCuenta(obj);
        }

        [Route("ObtenerFormasPagoPorTipoObjeto")]
        [HttpPost]
        public List<BE.FormaPago> ObtenerFormasPagoPorTipoObjeto(BE.TipoObjeto obj)
        {
            BL.FormaPago proxy = new BL.FormaPago();
            return proxy.ObtenerFormasPagoPorTipoObjeto(obj);
        }

        [Route("ObtenerEstatusPorTipoObjeto")]
        [HttpPost]
        public List<BE.Estatus> ObtenerEstatusPorTipoObjeto(BE.TipoObjeto obj)
        {
            BL.Estatus proxy = new BL.Estatus();
            return proxy.ObtenerEstatusPorTipoObjeto(obj);
        }

        [Route("ObtenerPersonalidadesJuridicasActivas")]
        [HttpPost]
        public List<BE.PersonalidadJuridica> ObtenerPersonalidadesJuridicasActivas()
        {
            BL.PersonalidadJuridica proxy = new BL.PersonalidadJuridica();
            return proxy.ObtenerPersonalidadesJuridicasActivas();
        }

        [Route("ObtenerIngredientesActivos")]
        [HttpPost]
        public List<BE.InventarioIngrediente> ObtenerIngredientesActivos(BE.Sucursal obj)
        {
            BL.Ingrediente proxy = new BL.Ingrediente();
            return proxy.ObtenerIngredientesActivos(obj);
        }

        [Route("ObtenerEntradaIngredientesActivos")]
        [HttpPost]
        public List<BE.EntradaIngrediente> ObtenerEntradaIngredientesActivos()
        {
            BL.Ingrediente proxy = new BL.Ingrediente();
            return proxy.ObtenerEntradaIngredientesActivos();
        }
    }
}
