using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Activo : Base
    {
        public BE.Activo GuardarActivo(BE.Activo obj)
        {
            BE.Activo retorno = new BE.Activo();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Activo_spInsActivo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_ActivoId", MySqlDbType.Int32, 12).Value = obj.ActivoId;
                    cmd.Parameters.Add("_SubCuentaFinalId", MySqlDbType.Int32, 12).Value = obj.SubCuentaFinalId;
                    cmd.Parameters.Add("_Monto", MySqlDbType.Decimal, 12).Value = obj.Monto;
                    cmd.Parameters.Add("_Fecha", MySqlDbType.DateTime, 12).Value = obj.Fecha;
                    cmd.Parameters.Add("_Factura", MySqlDbType.VarChar, obj.Factura.Length).Value = obj.Factura;
                    cmd.Parameters.Add("_Descripcion", MySqlDbType.VarChar, obj.Descripcion.Length).Value = obj.Descripcion;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;
                    cmd.Parameters.Add("_ProveedorId", MySqlDbType.Int32, 12).Value = obj.ActivoProveedor.ProveedorId;
                    cmd.Parameters.Add("_FormaPagoId", MySqlDbType.Int32, 12).Value = obj.FormaPagoId;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Activo
                                {
                                    ActivoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ActivoId")))
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public List<BE.Activo> ObtenerActivosPorFecha(BE.ReporteTemplate obj)
        {
            List<BE.Activo> retorno = new List<BE.Activo>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Activo_spSelActivosPorFecha", cn))
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
                                BE.Activo tmp = new BE.Activo
                                {
                                    ActivoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ActivoId"))),
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
