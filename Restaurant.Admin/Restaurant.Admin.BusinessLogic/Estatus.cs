using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Estatus
    {
        private DC.Estatus data = null;
        public Estatus()
        {
            this.data = new DC.Estatus();
        }

        public List<BE.Estatus> ObtenerEstatusPorTipoObjeto(BE.TipoObjeto obj)
        {
            return data.ObtenerEstatusPorTipoObjeto(obj);
        }
    }
}
