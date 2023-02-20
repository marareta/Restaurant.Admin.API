using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class UsuarioCredenciales
    {
        public int UsuarioCredencialesId { get; set; }

        public int UsuarioId { get; set; }

        public string NombreUsuario { get; set; }

        public string Password { get; set; }

        public Usuario Usuario { get; set; }
    }
}
