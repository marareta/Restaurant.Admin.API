using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class TraspasoIngrediente
    {
        public int TraspasoIngredienteId { get; set; }
        public int TraspasoId { get; set; }
        public int IngredienteId { get; set; }
        public decimal Cantidad { get; set; }


        public Traspaso Traspaso { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
