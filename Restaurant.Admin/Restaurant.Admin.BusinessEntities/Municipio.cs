using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Municipio
    {
        public int MunicipioId { get; set; }
        public string Descripcion { get; set; }
        public int EstadoId { get; set; }
        public int EstatusId { get; set; }


        public Estado Estado { get; set; }
        public Estatus Estatus { get; set; }
        public List<Sucursal> Sucursales { get; set; }
    }
}
