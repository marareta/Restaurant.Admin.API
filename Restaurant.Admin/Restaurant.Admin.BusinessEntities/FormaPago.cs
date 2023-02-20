using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class FormaPago
    {
        public int FormaPagoId { get; set; }
        public string Descripcion { get; set; }
        public int EstatusId { get; set; }
        public int AplicaReferencia { get; set; }


        public Estatus Estatus { get; set; }
        public List<VentaFormaPago> VentaFormasPago { get; set; }
        public List<CorteDiario> CortesDiarios { get; set; }
        public List<Costo> Costos { get; set; }
        public List<Gasto> Gastos { get; set; }
        public List<Capital> Capitales { get; set; }
        public List<Activo> Activos { get; set; }
    }
}
