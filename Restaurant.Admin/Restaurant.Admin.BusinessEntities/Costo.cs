using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Costo
    {
        public int CostoId { get; set; }
        public int SubCuentaId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Factura { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public int FormaPagoId { get; set; }
        public int SucursalId { get; set; }
        public int CostoMatrizId { get; set; }

        public SubCuenta SubCuenta { get; set; }
        public Usuario Usuario { get; set; }
        public CostoProveedor CostoProveedor { get; set; }
        public FormaPago FormaPago { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}
