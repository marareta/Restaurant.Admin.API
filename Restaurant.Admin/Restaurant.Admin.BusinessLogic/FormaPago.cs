using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class FormaPago
    {
        private DC.FormaPago data = null;
        public FormaPago()
        {
            this.data = new DC.FormaPago();
        }

        public List<BE.FormaPago> ObtenerFormasPagoPorTipoObjeto(BE.TipoObjeto obj)
        {
            return data.ObtenerFormasPagoPorTipoObjeto(obj);
        }
    }
}
