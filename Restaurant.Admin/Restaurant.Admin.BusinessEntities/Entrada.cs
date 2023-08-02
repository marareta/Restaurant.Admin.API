using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Entrada
    {
        public int EntradaId { get; set; }
        public int UsuarioId { get; set; }
        public int SucursalId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int ProveedorId { get; set; }


        public Usuario Usuario { get; set; }
        public Sucursal Sucursal { get; set; }
        public List<EntradaIngrediente> EntradaIngredientes { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
