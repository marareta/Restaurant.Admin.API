using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Activo
    {
        public int ActivoId { get; set; }
        public int SubCuentaFinalId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Factura { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public int FormaPagoId { get; set; }
        public int SucursalId { get; set; }


        public SubCuentaFinal SubCuentaFinal { get; set; }
        public Usuario Usuario { get; set; }
        public FormaPago FormaPago { get; set; }
        public ActivoProveedor ActivoProveedor { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}
