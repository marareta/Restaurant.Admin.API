using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class ProductoIngrediente
    {
        public int ProductoIngredienteId { get; set; }
        public int ProductoId { get; set; }
        public int IngredienteId { get; set; }
        public decimal Cantidad { get; set; }


        public Producto Producto { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
