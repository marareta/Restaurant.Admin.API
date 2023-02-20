using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class TipoObjetoEstatus
    {
        public int TipoObjetoEstatusId { get; set; }
        public int TipoObjetoId { get; set; }
        public int EstatusId { get; set; }


        public TipoObjeto TipoObjeto { get; set; }
        public Estatus Estatus { get; set; }
    }
}
