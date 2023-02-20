using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class SubCuentaFinal
    {
        public int SubCuentaFinalId { get; set; }
        public string Descripcion { get; set; }
        public int SubCuentaId { get; set; }
        public int EstatusId { get; set; }

        public SubCuenta SubCuenta { get; set; }
        public Estatus Estatus { get; set; }
        public List<Gasto> Gastos { get; set; }
        public List<Activo> Activos { get; set; }
    }
}
