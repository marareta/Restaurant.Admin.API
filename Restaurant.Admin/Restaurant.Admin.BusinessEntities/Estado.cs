using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string Descripcion { get; set; }
        public int PaisId { get; set; }
        public int EstatusId { get; set; }


        public Pais Pais { get; set; }
        public Estatus Estatus { get; set; }
        public List<Municipio> Municipios { get; set; }
    }
}
