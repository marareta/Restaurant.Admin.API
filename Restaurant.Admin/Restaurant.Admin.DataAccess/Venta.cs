using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Venta : Base
    {
        public List<Int32> ObtenerYearsDisponiblesVentas()
        {
            List<Int32> retorno = new List<Int32>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spSelYearsDisponiblesVentas", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("_VentaId", MySqlDbType.Int32, 12).Value = obj.VentaId;
                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                retorno.Add(Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("YearField"))));
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public BE.Venta GuardarVenta(BE.Venta obj)
        {
            BE.Venta retorno = new BE.Venta();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spInsVenta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;
                    cmd.Parameters.Add("_VentaId", MySqlDbType.Int32, 12).Value = obj.VentaId;
                    cmd.Parameters.Add("_UsuarioVentaId", MySqlDbType.Int32, 12).Value = obj.UsuarioVentaId;
                    cmd.Parameters.Add("_Total", MySqlDbType.Decimal, 12).Value = obj.VentaDetalle.Total;
                    cmd.Parameters.Add("_Descuento", MySqlDbType.Decimal, 12).Value = obj.VentaDetalle.Descuento;
                    cmd.Parameters.Add("_Cambio", MySqlDbType.Decimal, 12).Value = obj.VentaDetalle.Cambio;
                    cmd.Parameters.Add("_TipoVentaId", MySqlDbType.Int32, 12).Value = obj.TipoVenta.TipoVentaId;
                    cmd.Parameters.Add("_Comentarios", MySqlDbType.VarChar, obj.Comentarios.Length).Value = obj.Comentarios;
                    cmd.Parameters.Add("_IvaPct", MySqlDbType.Decimal, 12).Value = obj.VentaDetalle.IvaPct;
                    cmd.Parameters.Add("_Subtotal", MySqlDbType.Decimal, 12).Value = obj.VentaDetalle.Subtotal;
                    cmd.Parameters.Add("_EstatusId", MySqlDbType.Int32, 12).Value = obj.EstatusId;
                    cmd.Parameters.Add("_IvaTotal", MySqlDbType.Decimal, 12).Value = obj.VentaDetalle.IvaTotal;
                    cmd.Parameters.Add("_FechaVenta", MySqlDbType.DateTime, 12).Value = obj.FechaVenta;
                    cmd.Parameters.Add("_CostoEnvio", MySqlDbType.Decimal, 12).Value = obj.VentaDetalle.CostoEnvio;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Venta
                                {
                                    VentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("VentaMatrizId")))
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public BE.CorteDiario GuardarCorteDiario(BE.CorteDiario obj)
        {
            BE.CorteDiario retorno = new BE.CorteDiario();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spInsCortediarioMatriz", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_CorteDiarioSucursalId", MySqlDbType.Int32, 12).Value = obj.CorteDiarioId;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;
                    cmd.Parameters.Add("_Fecha", MySqlDbType.DateTime, 12).Value = obj.Fecha;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;
                    cmd.Parameters.Add("_MontoInicial", MySqlDbType.Decimal, 12).Value = obj.MontoInicial;
                    cmd.Parameters.Add("_MontoFinal", MySqlDbType.Decimal, 12).Value = obj.MontoFinal;
                    cmd.Parameters.Add("_FechaRegistroMontoInicial", MySqlDbType.DateTime, 12).Value = obj.FechaRegistroMontoInicial;
                    cmd.Parameters.Add("_FechaRegistroMontoFinal", MySqlDbType.DateTime, 12).Value = obj.FechaRegistroMontoFinal;
                    cmd.Parameters.Add("_FormaPagoId", MySqlDbType.Int32, 12).Value = obj.FormaPagoId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.CorteDiario
                                {
                                    CorteDiarioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("CorteDiarioId")))
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public void EliminarVentaProductos(BE.Venta obj)
        {
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spDelVentaProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_VentaId", MySqlDbType.Int32, 12).Value = obj.VentaId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        
                    }
                }
            }
        }

        public void GuardarVentaFormaPago(BE.VentaFormaPago obj)
        {
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spInsVentaFormaPago", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_VentaId", MySqlDbType.Int32, 12).Value = obj.VentaId;
                    cmd.Parameters.Add("_FormaPagoId", MySqlDbType.Int32, 12).Value = obj.FormaPagoId;
                    cmd.Parameters.Add("_Total", MySqlDbType.Decimal, 12).Value = obj.Total;
                    cmd.Parameters.Add("_Referencia", MySqlDbType.String, obj.Referencia.Length).Value = obj.Referencia;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {

                    }
                }
            }
        }

        public BE.VentaProducto GuardarVentaProducto(BE.VentaProducto obj)
        {
            BE.VentaProducto retorno = new BE.VentaProducto();
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spInsVentaProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_VentaId", MySqlDbType.Int32, 12).Value = obj.VentaId;
                    cmd.Parameters.Add("_ProductoId", MySqlDbType.Int32, 12).Value = obj.Producto.ProductoId;
                    cmd.Parameters.Add("_Cantidad", MySqlDbType.Decimal, 12).Value = obj.Cantidad;
                    cmd.Parameters.Add("_Descuento", MySqlDbType.Decimal, 12).Value = obj.Descuento;
                    cmd.Parameters.Add("_Total", MySqlDbType.Decimal, 12).Value = obj.Total;
                    cmd.Parameters.Add("_Nota", MySqlDbType.String, obj.Nota.Length).Value = obj.Nota;
                    cmd.Parameters.Add("_VentaProductoId", MySqlDbType.Int32, 12).Value = obj.VentaProductoId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno.VentaProductoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("VentaProductoId")));
                            }
                        }
                    }
                }

                return retorno;
            }
        }
    }
}
