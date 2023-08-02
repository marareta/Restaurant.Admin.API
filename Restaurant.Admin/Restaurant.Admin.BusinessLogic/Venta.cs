using System;
using System.Collections.Generic;
using System.Text;
using DC = Restaurant.Admin.DataAccess;
using BE = Restaurant.Admin.BusinessEntities;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Configuration;

namespace Restaurant.Admin.BusinessLogic
{
    public class Venta
    {
        private DC.Venta data = null;
        public Venta()
        {
            this.data = new DC.Venta();
        }

        public List<Int32> ObtenerYearsDisponiblesVentas()
        {
            return data.ObtenerYearsDisponiblesVentas();
        }

        public List<BE.CorteDiario> GuardarCorteDiario(List<BE.CorteDiario> lst)
        {
            foreach(var obj in lst)
            {
                BE.CorteDiario tmp = data.GuardarCorteDiario(obj);
                if(tmp.CorteDiarioId != 0)
                {
                    obj.CorteDiarioMatrizId = tmp.CorteDiarioId;
                }
            }
            return lst;
        }

        public List<BE.Venta> GuardarVentas(List<BE.Venta> lst)
        {
            foreach(var obj in lst)
            {
                BE.Venta venta = data.GuardarVenta(obj);
                if(venta.VentaId != 0)
                {
                    obj.VentaMatrizId= venta.VentaId;
                    //Se eliminan los productos por si es una venta pendiente
                    data.EliminarVentaProductos(venta);

                    foreach (var vp in obj.VentaProductos)
                    {
                        vp.VentaId = venta.VentaId;
                        BE.VentaProducto vptmp = data.GuardarVentaProducto(vp);
                    }

                    foreach (var vfp in obj.VentaFormasPago)
                    {
                        vfp.VentaId = venta.VentaId;
                        data.GuardarVentaFormaPago(vfp);
                    }
                }
            }

            //if (obj.VentaCliente != null)
            //{
            //    if (obj.VentaCliente.Cliente != null)
            //    {
            //        obj.VentaCliente.VentaId = venta.VentaId;
            //        int clienteDireccionId = 0;
            //        if (obj.VentaCliente.Cliente.ClienteDirecciones != null)
            //        {
            //            clienteDireccionId = obj.VentaCliente.Cliente.ClienteDirecciones[0].ClienteDireccionId;
            //        }
            //        BE.VentaCliente res = data.GuardarVentaCliente(obj.VentaCliente, clienteDireccionId);
            //    }
            //}

            return lst;
        }
    }
}
