﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Capital : Base
    {
        public BE.Capital GuardarCapital(BE.Capital obj)
        {
            BE.Capital retorno = new BE.Capital();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Capital_spInsCapital", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_CapitalId", MySqlDbType.Int32, 12).Value = obj.CapitalId;
                    cmd.Parameters.Add("_SubCuentaId", MySqlDbType.Int32, 12).Value = obj.SubCuentaId;
                    cmd.Parameters.Add("_Monto", MySqlDbType.Decimal, 12).Value = obj.Monto;
                    cmd.Parameters.Add("_Fecha", MySqlDbType.DateTime, 12).Value = obj.Fecha;
                    cmd.Parameters.Add("_Descripcion", MySqlDbType.VarChar, obj.Descripcion.Length).Value = obj.Descripcion;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;
                    cmd.Parameters.Add("_FormaPagoId", MySqlDbType.Int32, 12).Value = obj.FormaPagoId;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Capital
                                {
                                    CapitalId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("CapitalId")))
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public List<BE.Capital> ObtenerCapitalPorFecha(BE.ReporteTemplate obj)
        {
            List<BE.Capital> retorno = new List<BE.Capital>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Capital_spSelCapitalesPorFecha", cn))
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
                                BE.Capital tmp = new BE.Capital
                                {
                                    CapitalId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("CapitalId"))),
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
                                    Monto = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Monto"))),
                                    Fecha = Convert.ToDateTime(dr.GetDateTime(dr.GetOrdinal("Fecha"))),
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
