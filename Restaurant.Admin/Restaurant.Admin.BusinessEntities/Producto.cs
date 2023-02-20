using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string DescripcionCorta { get; set; }
        public string DescripcionLarga { get; set; }
        public int EstatusId { get; set; }
        public int EsCombo { get; set; }


        public Estatus Estatus { get; set; }
        public ProductoPrecio ProductoPrecio { get; set; }
        public ProductoCategoria ProductoCategoria { get; set; }
        public List<VentaProducto> VentaProductos { get; set; }
        public List<ProductoTipoVentaPrecio> ProductosTipoVentasPrecio { get; set; }
        public List<ProductoPromocion> ProductoPromociones { get; set; }
        public ProductoImagen ProductoImagen { get; set; }
        public List<ProductoIngrediente> ProductoIngredientes { get; set; }
        public List<ProductoComboProducto> ProductoComboProductos { get; set; }
    }
}
