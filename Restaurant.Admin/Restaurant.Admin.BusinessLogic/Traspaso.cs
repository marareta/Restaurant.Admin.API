using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Traspaso
    {
        private DC.Traspaso data = null;
        public Traspaso()
        {
            this.data = new DC.Traspaso();
        }

        public BE.Traspaso GuardarTraspaso(BE.Traspaso obj)
        {
            BE.Traspaso retorno = data.GuardarTraspaso(obj);
            if (retorno.TraspasoId != 0)
            {
                foreach (var ing in obj.TraspasoIngredientes)
                {
                    if (ing.Cantidad != 0)
                    {
                        data.GuardarTraspasoIngrediente(ing, retorno);
                    }
                }
            }
            return retorno;
        }
    }
}
