using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Inventario
    {
        public int InventarioId { get; set; }
        public int UsuarioId { get; set; }
        public int SucursalId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }


        public Usuario Usuario { get; set; }
        public Sucursal Sucursal { get; set; }
        public List<InventarioIngrediente> InventarioIngredientes { get; set; }
    }
}
