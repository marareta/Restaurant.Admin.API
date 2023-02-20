using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class TipoComplemento
    {
        public int TipoComplementoId { get; set; }
        public string Descripcion { get; set; }
        public int EstatusId { get; set; }


        public Estatus Estatus { get; set; }
        public List<Complemento> Complementos { get; set; }
    }
}
