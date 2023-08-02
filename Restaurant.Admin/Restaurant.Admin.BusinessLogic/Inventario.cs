using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;
using System.Text.Json;

namespace Restaurant.Admin.BusinessLogic
{
    public class Inventario
    {
        private DC.Inventario data = null;
        public Inventario()
        {
            this.data = new DC.Inventario();
        }

        public BE.Inventario GuardarInventario(BE.Inventario obj)
        {
            BE.Inventario retorno = new BE.Inventario();
            try
            {
                retorno = data.GuardarInventario(obj);
                if (retorno.InventarioId != 0)
                {
                    foreach (var ing in obj.InventarioIngredientes)
                    {
                        if(ing.Modificado == "1")
                        {
                            data.GuardarInventarioIngrediente(ing, retorno);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = "";
                if (ex.Message != null)
                {
                    error += "Message: " + ex.Message.ToString() + ". ";
                }
                if (ex.Source != null)
                {
                    error += "Source: " + ex.Source.ToString() + ". ";
                }

                BE.Log objLog = new BE.Log
                {
                    LogDescripcion = error,
                    Response = "",
                    TipoLog = new BE.TipoLog
                    {
                        Descripcion = "Error"
                    }
                };
                BusinessLogic.Log dataLog = new BusinessLogic.Log();
                dataLog.GuardarLog(objLog);
            }
            return retorno;
        }


    }
}
