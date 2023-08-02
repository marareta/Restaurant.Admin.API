using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Ingrediente
    {
        public int IngredienteId { get; set; }
        public string Descripcion { get; set; }
        public int EstatusId { get; set; }
        public int AplicaInventario { get; set; }
        public decimal Porcion { get; set; }
        public decimal Costo { get; set; }


        public Estatus Estatus { get; set; }
        public List<ProductoIngrediente> ProductoIngredientes { get; set; }
        public List<InventarioIngrediente> InventarioIngredientes { get; set; }
        public List<EntradaIngrediente> EntradaIngredientes { get; set; }
        public InventarioIngredienteMinimo InventarioIngredienteMinimo { get; set; }
        public IngredienteUnidad IngredienteUnidad { get; set; }
        public IngredienteStock IngredienteStock { get; set; }
        public List<TraspasoIngrediente> TraspasoIngredientes { get; set; }
    }
}
