using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class CostoProveedor
    {
        public int CostoProveedorId { get; set; }
        public int ProveedorId { get; set; }
        public int CostoId { get; set; }


        public Proveedor Proveedor { get; set; }
        public Costo Costo { get; set; }
    }
}
