using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class ProductoCategoria
    {
        public int ProductoCategoriaId { get; set; }
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }


        public Producto Producto { get; set; }
        public Categoria Categoria { get; set; }
    }
}
