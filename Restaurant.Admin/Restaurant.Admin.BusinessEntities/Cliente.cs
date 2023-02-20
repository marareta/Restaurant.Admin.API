using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public int EstatusId { get; set; }


        public Estatus Estatus { get; set; }
        public List<ClienteDireccion> ClienteDirecciones { get; set; }
        public List<VentaCliente> VentasCliente { get; set; }
    }
}
