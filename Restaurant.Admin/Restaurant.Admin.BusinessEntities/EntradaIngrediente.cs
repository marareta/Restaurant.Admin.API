using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class EntradaIngrediente
    {
        public int EntradaIngredienteId { get; set; }
        public int EntradaId { get; set; }
        public int IngredienteId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Presentacion { get; set; }


        public Entrada Entrada { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
