using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class IngredienteUnidad
    {
        public int IngredienteUnidadId { get; set; }
        public int IngredienteId { get; set; }
        public int UnidadId { get; set; }


        public Ingrediente Ingrediente { get; set; }
        public Unidad Unidad { get; set; }
    }
}
