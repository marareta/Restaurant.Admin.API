using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Activo
    {
        private DC.Activo data = null;
        public Activo()
        {
            this.data = new DC.Activo();
        }

        public BE.Activo GuardarActivo(BE.Activo obj)
        {
            return data.GuardarActivo(obj);
        }
    }
}
