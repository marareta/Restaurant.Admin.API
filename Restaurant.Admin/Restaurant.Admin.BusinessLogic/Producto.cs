using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Producto
    {
        private DC.Producto data = null;
        public Producto()
        {
            this.data = new DC.Producto();
        }

        public BE.Producto ObtenerProductoPorId(BE.Producto obj)
        {
            BE.Producto retorno = data.ObtenerProductoPorId(obj);
            retorno.ProductoIngredientes = data.ObtenerProductoIngredientes(obj);

            return retorno;
        }

        public BE.Producto GuardarProductoIngredientes(BE.Producto obj)
        {
            //Guardamos el precio
            data.GuardarProductoPrecio(obj);
            //Se eliminan los ingredientes del producto para volver a guardarlos actualizados
            data.EliminarProductoIngredientes(obj);
            foreach(BE.ProductoIngrediente pi in obj.ProductoIngredientes)
            {
                if(pi.Cantidad != 0)
                {
                    data.GuardarProductoIngrediente(pi);
                }
            }

            return obj;
        }

        public List<BE.Producto> ObtenerProductos()
        {
            List<BE.Producto> retorno = data.ObtenerProductos();
            //foreach(var p in retorno)
            //{
                //p.ProductoIngredientes = data.ObtenerProductoIngredientes(p);
            //}

            return retorno;
        }
    }
}
