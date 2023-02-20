using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Costo
    {
        private DC.Costo data = null;
        public Costo()
        {
            this.data = new DC.Costo();
        }

        public BE.Costo GuardarCosto(BE.Costo obj)
        {
            return data.GuardarCosto(obj);
        }
    }
}
