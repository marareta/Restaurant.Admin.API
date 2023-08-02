using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class IngredienteStock
    {
        public int IngredienteStockId { get; set; }
        public int IngredienteId { get; set; }
        public decimal Stock { get; set; }

        public Ingrediente Ingrediente { get; set; }
    }
}
