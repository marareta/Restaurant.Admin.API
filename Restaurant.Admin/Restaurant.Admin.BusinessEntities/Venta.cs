using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public int UsuarioVentaId { get; set; }
        public int EstatusId { get; set; }
        public int TipoVentaId { get; set; }
        public int SucursalId { get; set; }
        public string Comentarios { get; set; }
        public int VentaMatrizId { get; set; }


        public Usuario Usuario { get; set; }
        public Estatus Estatus { get; set; }
        public VentaDetalle VentaDetalle { get; set; }
        public List<VentaProducto> VentaProductos { get; set; }
        public List<VentaFormaPago> VentaFormasPago { get; set; }
        public TipoVenta TipoVenta { get; set; }
        public VentaCliente VentaCliente { get; set; }
        public VentaClienteDireccion VentaClienteDireccion { get; set; }
        public Sucursal Sucursal { get; set; }
        public List<VentaComplemento> VentaComplementos { get; set; }
    }
}
