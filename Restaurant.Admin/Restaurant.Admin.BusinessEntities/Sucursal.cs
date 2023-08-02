using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Sucursal
    {
        public int SucursalId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int MunicipioId { get; set; }
        public int EstatusId { get; set; }


        public Municipio Municipio { get; set; }
        public Estatus Estatus { get; set; }
        public List<Venta> Ventas { get; set; }
        public List<Costo> Costos { get; set; }
        public List<Activo> Activos { get; set; }
        public List<Gasto> Gastos { get; set; }
        public List<Capital> Capitales { get; set; }
        public List<UsuarioSucursal> UsuarioSucursales { get; set; }
        public List<Inventario> Inventarios { get; set; }
        public List<Entrada> Entradas { get; set; }
        public List<Traspaso> Traspasos { get; set; }
    }
}
