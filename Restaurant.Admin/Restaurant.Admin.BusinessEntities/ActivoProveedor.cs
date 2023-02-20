using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class ActivoProveedor
    {
        public int ActivoProveedorId { get; set; }
        public int ActivoId { get; set; }
        public int ProveedorId { get; set; }


        public Activo Activo { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
