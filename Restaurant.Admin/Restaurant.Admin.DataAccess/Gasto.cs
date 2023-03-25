using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Gasto : Base
    {
        public BE.Gasto GuardarGasto(BE.Gasto obj)
        {
            BE.Gasto retorno = new BE.Gasto();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Gasto_spInsGasto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_GastoId", MySqlDbType.Int32, 12).Value = obj.GastoId;
                    cmd.Parameters.Add("_SubCuentaFinalId", MySqlDbType.Int32, 12).Value = obj.SubCuentaFinalId;
                    cmd.Parameters.Add("_Monto", MySqlDbType.Decimal, 12).Value = obj.Monto;
                    cmd.Parameters.Add("_Fecha", MySqlDbType.DateTime, 12).Value = obj.Fecha;
                    cmd.Parameters.Add("_Factura", MySqlDbType.VarChar, obj.Factura.Length).Value = obj.Factura;
                    cmd.Parameters.Add("_Descripcion", MySqlDbType.VarChar, obj.Descripcion.Length).Value = obj.Descripcion;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;
                    cmd.Parameters.Add("_ProveedorId", MySqlDbType.Int32, 12).Value = obj.GastoProveedor.ProveedorId;
                    cmd.Parameters.Add("_FormaPagoId", MySqlDbType.Int32, 12).Value = obj.FormaPagoId;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Gasto
                                {
                                    GastoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("GastoId")))
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public List<BE.Gasto> ObtenerGastosPorFecha(BE.ReporteTemplate obj)
        {
            List<BE.Gasto> retorno = new List<BE.Gasto>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Gasto_spSelGastosPorFecha", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_FechaInicial", MySqlDbType.DateTime, 12).Value = obj.FechaInicio;
                    cmd.Parameters.Add("_FechaFinal", MySqlDbType.DateTime, 12).Value = obj.FechaFin;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.DatoEntero1;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.Gasto tmp = new BE.Gasto
                                {
                                    GastoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("GastoId"))),
                                    SubCuentaFinalId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SubCuentaFinalId"))),
                                    SubCuentaFinal = new BE.SubCuentaFinal
                                    {
                                        SubCuentaFinalId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SubCuentaFinalId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("SubCuentaFinal")),
                                        SubCuentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SubCuentaId"))),
                                        SubCuenta = new BE.SubCuenta
                                        {
                                            SubCuentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SubCuentaId"))),
                                            Descripcion = dr.GetString(dr.GetOrdinal("SubCuenta")),
                                            CuentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("CuentaId"))),
                                            Cuenta = new BE.Cuenta
                                            {
                                                CuentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("CuentaId"))),
                                                Descripcion = dr.GetString(dr.GetOrdinal("Cuenta"))
                                            }
                                        },
                                    },
                                    Monto = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Monto"))),
                                    Fecha = Convert.ToDateTime(dr.GetDateTime(dr.GetOrdinal("Fecha"))),
                                    Factura = dr.GetString(dr.GetOrdinal("Factura")),
                                    Descripcion = dr.GetString(dr.GetOrdinal("Descripcion")),
                                    SucursalId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SucursalId"))),
                                    Sucursal = new BE.Sucursal
                                    {
                                        SucursalId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SucursalId"))),
                                        Nombre = dr.GetString(dr.GetOrdinal("Sucursal"))
                                    },
                                    UsuarioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UsuarioId"))),
                                    Usuario = new BE.Usuario
                                    {
                                        UsuarioDatosGenerales = new BE.UsuarioDatosGenerales
                                        {
                                            Nombres = dr.GetString(dr.GetOrdinal("Nombre")),
                                            ApellidoPaterno = dr.GetString(dr.GetOrdinal("ApellidoPaterno")),
                                            ApellidoMaterno = dr.GetString(dr.GetOrdinal("ApellidoMaterno"))
                                        }
                                    },
                                    FormaPagoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("FormaPagoId"))),
                                    FormaPago = new BE.FormaPago
                                    {
                                        FormaPagoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("FormaPagoId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("FormaPago"))
                                    },
                                    GastoProveedor = new BE.GastoProveedor
                                    {
                                        ProveedorId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProveedorId"))),
                                        Proveedor = new BE.Proveedor
                                        {
                                            ProveedorId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProveedorId"))),
                                            Nombre = dr.GetString(dr.GetOrdinal("Proveedor")),
                                            RFC = dr.GetString(dr.GetOrdinal("ProveedorRFC"))
                                        }
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


    }
}
