using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.BusinessLogic
{
    public class Ingrediente
    {
        private DC.Ingrediente data = null;
        public Ingrediente()
        {
            this.data = new DC.Ingrediente();
        }

        public List<BE.InventarioIngrediente> ObtenerIngredientesActivos(BE.Sucursal obj)
        {
            List<BE.InventarioIngrediente> retorno = data.ObtenerIngredientesActivos(obj);
            foreach(BE.InventarioIngrediente ing in retorno)
            {
                BE.Inventario inventario = new BE.Inventario { 
                    Sucursal = new BE.Sucursal
                    {
                        Direccion = " background-color-red"
                    }
                };
                
                if(((ing.Ingrediente.IngredienteStock.Stock) * (decimal).9) > ing.Ingrediente.InventarioIngredienteMinimo.Minimo)
                {
                    inventario.Sucursal.Direccion = " background-color-green";
                }
                ing.Inventario = inventario;
            }

            return retorno;
        }

        public List<BE.EntradaIngrediente> ObtenerEntradaIngredientesActivos()
        {
            return data.ObtenerEntradaIngredientesActivos();
        }

        public List<BE.Ingrediente> ObtenerIngredientes()
        {
            return data.ObtenerIngredientes();
        }

        public BE.Ingrediente ObtenerIngredientePorId(BE.Ingrediente obj)
        {
            return data.ObtenerIngredientePorId(obj);
        }

        public BE.Ingrediente GuardarIngrediente(BE.Ingrediente obj)
        {
            BE.Ingrediente retorno = data.GuardarIngrediente(obj);
            obj.IngredienteId = retorno.IngredienteId;
            return retorno;
        }
    }
}
