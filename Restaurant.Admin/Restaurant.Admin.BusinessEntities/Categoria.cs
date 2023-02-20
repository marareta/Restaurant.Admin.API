using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public int EstatusId { get; set; }


        public Estatus Estatus { get; set; }
        public List<ProductoCategoria> ProductosCategorias { get; set; }
    }
}
