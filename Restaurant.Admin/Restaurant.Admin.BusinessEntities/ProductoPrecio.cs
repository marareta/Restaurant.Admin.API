using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class ProductoPrecio
    {
        public int ProductoPrecioId { get; set; }
        public int ProductoId { get; set; }
        public decimal Precio { get; set; }


        public Producto Producto { get; set; }
    }
}
