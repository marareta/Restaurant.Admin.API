using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class ProveedorFactura
    {
        public int ProveedorFacturaId { get; set; }
        public int ProveedorId { get; set; }
        public string FolioFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string Comentarios { get; set; }
        public int EstatusId { get; set; }


        public Proveedor Proveedor { get; set; }
        public Estatus Estatus { get; set; }
    }
}
