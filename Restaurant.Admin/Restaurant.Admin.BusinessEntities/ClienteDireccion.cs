using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class ClienteDireccion
    {
        public int ClienteDireccionId { get; set; }
        public int ClienteId { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Cp { get; set; }
        public string Colonia { get; set; }
        public string Comentarios { get; set; }
        public int EstatusId { get; set; }


        public Cliente Cliente { get; set; }
        public Estatus Estatus { get; set; }
        public List<VentaClienteDireccion> VentasClienteDirecciones { get; set; }
    }
}
