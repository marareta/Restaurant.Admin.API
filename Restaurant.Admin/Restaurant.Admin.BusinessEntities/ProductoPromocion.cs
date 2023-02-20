using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class ProductoPromocion
    {
        public int ProductoPromocionId { get; set; }
        public int ProductoId { get; set; }
        public int TipoPromocionId { get; set; }
        public decimal Valor { get; set; }


        public Producto Producto { get; set; }
        public TipoPromocion TipoPromocion { get; set; }
    }
}
