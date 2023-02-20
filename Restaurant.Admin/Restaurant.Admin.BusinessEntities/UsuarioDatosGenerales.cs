using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class UsuarioDatosGenerales
    {
        public int UsuarioDatosGeneralesId { get; set; }
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public Usuario Usuario { get; set; }
    }
}
