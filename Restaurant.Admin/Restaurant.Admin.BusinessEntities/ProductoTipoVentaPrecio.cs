using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class ProductoTipoVentaPrecio
    {
        public int ProductoTipoVentaPrecioId { get; set; }
        public int ProductoId { get; set; }
        public int TipoVentaId { get; set; }
        public decimal Precio { get; set; }


        public Producto Producto { get; set; }
        public TipoVenta TipoVenta { get; set; }
    }
}
