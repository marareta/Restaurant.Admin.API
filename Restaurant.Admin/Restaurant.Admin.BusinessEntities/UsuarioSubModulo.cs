using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class UsuarioSubModulo
    {
        public int UsuarioSubModuloId { get; set; }
        public int SubModuloId { get; set; }
        public int UsuarioId { get; set; }


        public SubModulo SubModulo { get; set; }
        public Usuario Usuario { get; set; }
    }
}
