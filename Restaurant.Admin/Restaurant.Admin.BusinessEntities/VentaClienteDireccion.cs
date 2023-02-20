using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class VentaClienteDireccion
    {
        public int VentaClienteDireccionId { get; set; }
        public int VentaId { get; set; }
        public int ClienteDireccionId { get; set; }


        public Venta Venta { get; set; }
        public ClienteDireccion ClienteDireccion { get; set; }
    }
}
