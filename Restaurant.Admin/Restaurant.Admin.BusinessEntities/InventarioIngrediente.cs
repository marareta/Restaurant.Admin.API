using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class InventarioIngrediente
    {
        public int InventarioIngredienteId { get; set; }
        public int InventarioId { get; set; }
        public int IngredienteId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ExistenciaAnterior { get; set; }
        public string Modificado { get; set; }

        public Inventario Inventario { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
