using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Estatus
    {
        public int EstatusId { get; set; }
        public string Descripcion { get; set; }



        public List<Usuario> Usuarios { get; set; }

        public List<TipoObjetoEstatus> TiposObjetoEstatus { get; set; }
        public List<Producto> Productos { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<Modulo> Modulos { get; set; }
        public List<SubModulo> SubModulos { get; set; }
        public List<Venta> Ventas { get; set; }
        public List<FormaPago> FormasPago { get; set; }
        public List<TipoVenta> TiposVenta { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<ClienteDireccion> ClienteDirecciones { get; set; }
        public List<Pais> Paises { get; set; }
        public List<Estado> Estados { get; set; }
        public List<Municipio> Municipios { get; set; }
        public List<Sucursal> Sucursales { get; set; }
        public List<PersonalidadJuridica> PersonalidadesJuridicas { get; set; }
        public List<Proveedor> Proveedores { get; set; }
        public List<TipoPromocion> TipoPromociones { get; set; }
        public List<Cuenta> Cuentas { get; set; }
        public List<SubCuenta> SubCuentas { get; set; }
        public List<SubCuentaFinal> SubCuentasFinales { get; set; }
        public List<TipoComplemento> TipoComplementos { get; set; }
        public List<Complemento> Complementos { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
    }
}
