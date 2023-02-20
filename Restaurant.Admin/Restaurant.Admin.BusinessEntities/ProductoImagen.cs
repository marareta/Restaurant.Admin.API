using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.BusinessEntities
{
    public class ProductoImagen
    {
        public int ProductoImagenId { get; set; }
        public int ProductoId { get; set; }
        public string Imagen { get; set; }


        public Producto Producto { get; set; }
    }
}
