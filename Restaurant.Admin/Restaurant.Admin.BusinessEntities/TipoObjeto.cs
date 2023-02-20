using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class TipoObjeto
    {
        public int TipoObjetoId { get; set; }
        public string Descripcion { get; set; }

        public List<TipoObjetoEstatus> TiposObjetosEstatus { get; set; }
    }
}
