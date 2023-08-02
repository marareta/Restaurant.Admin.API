using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Unidad
    {
        private DC.Unidad data = null;
        public Unidad()
        {
            this.data = new DC.Unidad();
        }

        public List<BE.Unidad> ObtenerUnidadesActivas()
        {
            return data.ObtenerUnidadesActivas();
        }
    }
}
