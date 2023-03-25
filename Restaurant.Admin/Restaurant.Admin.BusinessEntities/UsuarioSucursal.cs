using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class UsuarioSucursal
    {
        public int UsuarioSucursalId { get; set; }
        public int UsuarioId { get; set; }
        public int SucursalId { get; set; }


        public Usuario Usuario { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}
