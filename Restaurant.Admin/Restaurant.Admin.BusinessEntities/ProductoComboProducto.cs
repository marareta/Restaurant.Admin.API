using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class ProductoComboProducto
    {
        public int ProductoComboProductoId { get; set; }
        public int ProductoId { get; set; }
        public int ProductoComboId { get; set; }
        public int Grupo { get; set; }
        public bool Seleccionado { get; set; }


        public Producto Producto { get; set; }
        public Producto ProductoCombo { get; set; }
    }
}
