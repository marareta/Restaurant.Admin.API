using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class PersonalidadJuridica
    {
        public int PersonalidadJuridicaId { get; set; }
        public string Descripcion { get; set; }
        public int EstatusId { get; set; }


        public Estatus Estatus { get; set; }
        public List<Proveedor> Proveedores { get; set; }
    }
}
