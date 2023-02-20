using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class VentaProducto
    {
        public int VentaProductoId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public string Nota { get; set; }
        public int VentaProductoPadreId { get; set; }


        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
    }
}
