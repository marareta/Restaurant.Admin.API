using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public int EstatusId { get; set; }
        public string Nombre { get; set; }
        public int PersonalidadJuridicaId { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public string CP { get; set; }



        public Estatus Estatus { get; set; }
        public PersonalidadJuridica PersonalidadJuridica { get; set; }
        public List<CostoProveedor> CostosProveedor { get; set; }
        public List<GastoProveedor> GastosProveedor { get; set; }
        public List<ActivoProveedor> ActivosProveedor { get; set; }
    }
}
