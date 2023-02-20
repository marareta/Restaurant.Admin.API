using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class SubModulo
    {
        public int SubModuloId { get; set; }
        public string Descripcion { get; set; }
        public int ModuloId { get; set; }
        public int EstatusId { get; set; }
        public int Acceso { get; set; }


        public Modulo Modulo { get; set; }
        public Estatus Estatus { get; set; }
        public List<UsuarioSubModulo> UsuarioSubModulos { get; set; }
    }
}
