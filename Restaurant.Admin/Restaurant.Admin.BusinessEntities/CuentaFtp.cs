using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class CuentaFtp
    {
        public int CuentaFtpId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Servidor { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
