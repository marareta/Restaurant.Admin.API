using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int EstatusId { get; set; }


        public Estatus Estatus { get; set; }
        public UsuarioCredenciales UsuarioCredenciales { get; set; }
        public UsuarioDatosGenerales UsuarioDatosGenerales { get; set; }
        public List<UsuarioSubModulo> UsuarioSubModulos { get; set; }
        public List<Venta> Ventas { get; set; }
        public List<CorteDiario> CortesDiarios { get; set; }
        public List<Costo> Costos { get; set; }
        public List<Gasto> Gastos { get; set; }
        public List<Capital> Capitales { get; set; }
        public List<Activo> Activos { get; set; }
        public List<UsuarioSucursal> UsuarioSucursales { get; set; }
    }
}
