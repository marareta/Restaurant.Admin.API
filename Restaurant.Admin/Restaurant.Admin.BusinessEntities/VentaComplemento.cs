using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class VentaComplemento
    {
        public int VentaComplementoId { get; set; }
        public int VentaId { get; set; }
        public int ComplementoId { get; set; }


        public Complemento Complemento { get; set; }
        public Venta Venta { get; set; }
    }
}
