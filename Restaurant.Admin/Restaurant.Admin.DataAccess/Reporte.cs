using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Reporte : Base
    {
        public BE.ReporteTemplate ObtenerReporteEstadoResultados(BE.ReporteTemplate obj)
        {
            BE.ReporteTemplate retorno = new BE.ReporteTemplate();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Reportes_spSelEstadoResultados", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_FechaInicio", MySqlDbType.Date, 12).Value = obj.FechaInicio;
                    cmd.Parameters.Add("_FechaFin", MySqlDbType.Date, 12).Value = obj.FechaFin;
                    cmd.Parameters.Add("_Impuestos", MySqlDbType.Decimal, 12).Value = obj.DatoDecimal1;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.ReporteTemplate
                                {
                                    Id = 1,
                                    DatoDecimal1 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Ventas"))),
                                    DatoDecimal2 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("DescuentoSobreVentas"))),
                                    DatoDecimal3 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("VentasNetas"))),
                                    DatoDecimal4 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("ManoObra"))),
                                    DatoDecimal5 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("MateriaPrima"))),
                                    DatoDecimal6 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("CostoVentas"))),
                                    DatoDecimal7 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("UtilidadBruta"))),
                                    DatoDecimal8 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("GastosAdministrativos"))),
                                    DatoDecimal9 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("GastosVenta"))),
                                    DatoDecimal10 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("TotalGastos"))),
                                    DatoDecimal11 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("UtilidadAntesImpuestos"))),
                                    DatoDecimal12 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("ImpuestosUtilidad"))),
                                    DatoDecimal13 = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("UtilidadNeta")))
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public BE.ReporteTemplate ObtenerReporteVentasPorTipo(BE.ReporteTemplate obj)
        {
            BE.ReporteTemplate retorno = new BE.ReporteTemplate();
            List<BE.Venta> lst = new List<BE.Venta>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spSelReporteVentasTotales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_FechaInicio", MySqlDbType.Date, 12).Value = obj.FechaInicio;
                    cmd.Parameters.Add("_FechaFin", MySqlDbType.Date, 12).Value = obj.FechaFin;
                    cmd.Parameters.Add("_Tipo", MySqlDbType.Int32, 12).Value = obj.DatoEntero1;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.Venta tmp = new BE.Venta
                                {
                                    VentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ValorId"))),
                                    FechaVenta = Convert.ToDateTime(dr.GetDateTime(dr.GetOrdinal("Fecha"))),
                                    //FechaVenta = new DateTime(obj.FechaInicio.Year, Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("MesId"))), 1),
                                    VentaDetalle = new BE.VentaDetalle
                                    {
                                        Total = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Total")))
                                    }
                                };
                                lst.Add(tmp);
                            }
                        }
                    }
                }
            }
            retorno.Ventas = lst;
            retorno.FechaInicio = obj.FechaInicio;
            retorno.FechaFin = obj.FechaFin;
            retorno.DatoEntero1 = obj.DatoEntero1;
            retorno.SucursalId = obj.SucursalId;
            
            return retorno;
        }

        public List<BE.Venta> ObtenerVentasPorFechas(BE.ReporteTemplate obj)
        {
            List<BE.Venta> retorno = new List<BE.Venta>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spSelReporteVentasPorFechas", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_FechaInicio", MySqlDbType.Date, 12).Value = obj.FechaInicio;
                    cmd.Parameters.Add("_FechaFin", MySqlDbType.Date, 12).Value = obj.FechaFin;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.Venta tmp = new BE.Venta
                                {
                                    VentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("VentaId"))),
                                    FechaVenta = Convert.ToDateTime(dr.GetDateTime(dr.GetOrdinal("FechaVenta"))),
                                    //FechaVenta = new DateTime(obj.FechaInicio.Year, Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("MesId"))), 1),
                                    VentaDetalle = new BE.VentaDetalle
                                    {
                                        Total = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Total")))
                                    },
                                    TipoVenta = new BE.TipoVenta
                                    {
                                        Descripcion = dr.GetString(dr.GetOrdinal("TipoVenta"))
                                    }
                                };
                                retorno.Add(tmp);
                            }
                        }
                    }
                }
            }
            return retorno;
        }

        public List<BE.Venta> ObtenerVentasPorTipoVenta(BE.ReporteTemplate obj)
        {
            List<BE.Venta> retorno = new List<BE.Venta>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spSelReporteVentasPorTipoVenta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_FechaInicio", MySqlDbType.Date, 12).Value = obj.FechaInicio;
                    cmd.Parameters.Add("_FechaFin", MySqlDbType.Date, 12).Value = obj.FechaFin;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.Venta tmp = new BE.Venta
                                {
                                    VentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("Cantidad"))),
                                    VentaDetalle = new BE.VentaDetalle
                                    {
                                        Total = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Total")))
                                    },
                                    TipoVentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("TipoVentaId"))),
                                    TipoVenta = new BE.TipoVenta
                                    {
                                        Descripcion = dr.GetString(dr.GetOrdinal("TipoVenta")),
                                        TipoVentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("TipoVentaId")))
                                    }
                                };
                                retorno.Add(tmp);
                            }
                        }
                    }
                }
            }
            return retorno;
        }

        public List<BE.Venta> ObtenerVentasTotalesPorDiaSemana(BE.ReporteTemplate obj)
        {
            List<BE.Venta> retorno = new List<BE.Venta>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spSelReporteVentasTotalesPorDiaSemana", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_FechaInicio", MySqlDbType.Date, 12).Value = obj.FechaInicio;
                    cmd.Parameters.Add("_FechaFin", MySqlDbType.Date, 12).Value = obj.FechaFin;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.Venta tmp = new BE.Venta
                                {
                                    VentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("NumeroDiaSemana"))),
                                    VentaDetalle = new BE.VentaDetalle
                                    {
                                        Total = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Total")))
                                    },
                                    TipoVenta = new BE.TipoVenta
                                    {
                                        Descripcion = dr.GetString(dr.GetOrdinal("DiaSemana"))
                                    }
                                };
                                retorno.Add(tmp);
                            }
                        }
                    }
                }
            }
            return retorno;
        }

        public List<BE.VentaProducto> ObtenerReporteVentasProductosMasVendidos(BE.ReporteTemplate obj)
        {
            List<BE.VentaProducto> retorno = new List<BE.VentaProducto>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spSelReporteVentasProductosMasVendidos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_FechaInicio", MySqlDbType.Date, 12).Value = obj.FechaInicio;
                    cmd.Parameters.Add("_FechaFin", MySqlDbType.Date, 12).Value = obj.FechaFin;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.VentaProducto tmp = new BE.VentaProducto
                                {
                                    ProductoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProductoId"))),
                                    Producto = new BE.Producto
                                    {
                                        ProductoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProductoId"))),
                                        DescripcionCorta = dr.GetString(dr.GetOrdinal("Producto"))
                                    },
                                    Cantidad = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Cantidad")))
                                };
                                retorno.Add(tmp);
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public List<BE.VentaProducto> ObtenerReporteVentasProductosMenosVendidos(BE.ReporteTemplate obj)
        {
            List<BE.VentaProducto> retorno = new List<BE.VentaProducto>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spSelReporteVentasProductosMenosVendidos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_FechaInicio", MySqlDbType.Date, 12).Value = obj.FechaInicio;
                    cmd.Parameters.Add("_FechaFin", MySqlDbType.Date, 12).Value = obj.FechaFin;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.VentaProducto tmp = new BE.VentaProducto
                                {
                                    ProductoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProductoId"))),
                                    Producto = new BE.Producto
                                    {
                                        ProductoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProductoId"))),
                                        DescripcionCorta = dr.GetString(dr.GetOrdinal("Producto"))
                                    },
                                    Cantidad = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Cantidad")))
                                };
                                retorno.Add(tmp);
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public List<BE.VentaProducto> ObtenerReporteVentasProductosVendidos(BE.ReporteTemplate obj)
        {
            List<BE.VentaProducto> retorno = new List<BE.VentaProducto>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spSelReporteVentasProductosVendidos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_FechaInicio", MySqlDbType.Date, 12).Value = obj.FechaInicio;
                    cmd.Parameters.Add("_FechaFin", MySqlDbType.Date, 12).Value = obj.FechaFin;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.VentaProducto tmp = new BE.VentaProducto
                                {
                                    ProductoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProductoId"))),
                                    Producto = new BE.Producto
                                    {
                                        ProductoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProductoId"))),
                                        DescripcionCorta = dr.GetString(dr.GetOrdinal("Producto"))
                                    },
                                    Cantidad = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Cantidad")))
                                };
                                retorno.Add(tmp);
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public List<BE.VentaFormaPago> ObtenerReporteVentasFormasPago(BE.ReporteTemplate obj)
        {
            List<BE.VentaFormaPago> retorno = new List<BE.VentaFormaPago>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Venta_spSelReporteVentasFormasPago", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_FechaInicio", MySqlDbType.Date, 12).Value = obj.FechaInicio;
                    cmd.Parameters.Add("_FechaFin", MySqlDbType.Date, 12).Value = obj.FechaFin;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.VentaFormaPago tmp = new BE.VentaFormaPago
                                {
                                    FormaPagoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("FormaPagoId"))),
                                    FormaPago = new BE.FormaPago
                                    {
                                        FormaPagoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("FormaPagoId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("FormaPago"))
                                    },
                                    Total = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Total")))
                                };
                                retorno.Add(tmp);
                            }
                        }
                    }
                }
            }

            return retorno;
        }
    }
}
