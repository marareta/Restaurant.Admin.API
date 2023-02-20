using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class VentaFormaPago
    {
        public int VentaFormaPagoId { get; set; }
        public int VentaId { get; set; }
        public int FormaPagoId { get; set; }
        public decimal Total { get; set; }
        public string Referencia { get; set; }


        public Venta Venta { get; set; }
        public FormaPago FormaPago { get; set; }
    }
}
