using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Log
    {
        private DC.Log data = null;
        public Log()
        {
            this.data = new DC.Log();
        }

        public void GuardarLog(BE.Log obj)
        {
            data.GuardarLog(obj);
        }
    }
}
