using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Complemento
    {
        public int ComplementoId { get; set; }
        public string Descripcion { get; set; }
        public int TipoComplementoId { get; set; }
        public int EstatusId { get; set; }


        public TipoComplemento TipoComplemento { get; set; }
        public Estatus Estatus { get; set; }
        public List<VentaComplemento> VentaComplementos { get; set; }
    }
}
