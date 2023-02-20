using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class SubCuenta
    {
        public int SubCuentaId { get; set; }
        public string Descripcion { get; set; }
        public int CuentaId { get; set; }
        public int EstatusId { get; set; }


        public Cuenta Cuenta { get; set; }
        public Estatus Estatus { get; set; }
        public List<Costo> Costos { get; set; }
        public List<SubCuentaFinal> SubCuentasFinales { get; set; }
        public List<Capital> Capitales { get; set; }
    }
}
