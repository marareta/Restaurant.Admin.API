 using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Traspaso
    {
        public int TraspasoId { get; set; }
        public int UsuarioId { get; set; }
        public int SucursalOrigenId { get; set; }
        public int SucursalDestinoId { get; set; }
        public DateTime Fecha { get; set; }


        public Usuario Usuario { get; set; }
        public Sucursal SucursalOrigen { get; set; }
        public Sucursal SucursalDestino { get; set; }
        public List<TraspasoIngrediente> TraspasoIngredientes { get; set; }
    }
}
