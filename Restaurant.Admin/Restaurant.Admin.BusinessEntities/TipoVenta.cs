using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class TipoVenta
    {
        public int TipoVentaId { get; set; }
        public string Descripcion { get; set; }
        public int EstatusId { get; set; }
        public int AplicaCliente { get; set; }
        public int AplicaDireccion { get; set; }
        public int AplicaTicketCliente { get; set; }
        public int AplicaTicketCocina { get; set; }
        public int AplicaTicketReparto { get; set; }
        public int AplicaPagoInicial { get; set; }
        public int AplicaVentaPendiente { get; set; }
        public int EsPlataformaComida { get; set; }


        public Estatus Estatus { get; set; }
        public List<Venta> Ventas { get; set; }
        public List<ProductoTipoVentaPrecio> ProductosTipoVentasPrecio { get; set; }
    }
}
