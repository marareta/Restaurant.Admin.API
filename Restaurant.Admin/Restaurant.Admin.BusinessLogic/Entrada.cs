using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Entrada
    {
        private DC.Entrada data = null;
        public Entrada()
        {
            this.data = new DC.Entrada();
        }

        public BE.Entrada GuardarEntrada(BE.Entrada obj)
        {
            BE.Entrada retorno = data.GuardarEntrada(obj);
            if (retorno.EntradaId != 0)
            {
                foreach (var ing in obj.EntradaIngredientes)
                {
                    if (ing.Cantidad != 0)
                    {
                        data.GuardarEntradaIngrediente(ing, retorno);
                    }
                }
            }

            return retorno;
        }
    }
}
