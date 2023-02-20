using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class VentaCliente
    {
        public int VentaClienteId { get; set; }
        public int VentaId { get; set; }
        public int ClienteId { get; set; }


        public Venta Venta { get; set; }
        public Cliente Cliente { get; set; }
    }
}
