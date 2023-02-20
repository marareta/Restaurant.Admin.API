using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class VentaDetalle
    {
        public int VentaDetalleId { get; set; }
        public int VentaId { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IvaPct { get; set; }
        public decimal IvaTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Cambio { get; set; }


        public Venta Venta { get; set; }
    }
}
