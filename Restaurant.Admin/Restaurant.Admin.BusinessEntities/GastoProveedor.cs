using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class GastoProveedor
    {
        public int GastoProveedorId { get; set; }
        public int ProveedorId { get; set; }
        public int GastoId { get; set; }


        public Proveedor Proveedor { get; set; }
        public Gasto Gasto { get; set; }
    }
}
