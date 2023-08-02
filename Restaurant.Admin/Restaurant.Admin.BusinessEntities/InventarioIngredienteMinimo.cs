using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class InventarioIngredienteMinimo
    {
        public int InventarioIngredienteMinimoId { get; set; }
        public int IngredienteId { get; set; }
        public decimal Minimo { get; set; }


        public Ingrediente Ingrediente { get; set; }
    }
}
