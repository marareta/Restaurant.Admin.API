using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class SubCuenta : Base
    {
        public List<BE.SubCuentaFinal> ObtenerSubCuentasFinalesPorSubCuenta(BE.SubCuenta obj)
        {
            List<BE.SubCuentaFinal> lst = null;

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Administracion_spSelSubCuentasFinalesPorSubCuenta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_SubCuentaId", MySqlDbType.Int32, 12).Value = obj.SubCuentaId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            lst = new List<BE.SubCuentaFinal>();
                            while (dr.Read())
                            {
                                BE.SubCuentaFinal obj2 = new BE.SubCuentaFinal
                                {
                                    Descripcion = dr.GetString(dr.GetOrdinal("SubCuentaFinal")),
                                    SubCuentaFinalId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SubCuentaFinalId"))),
                                    SubCuentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SubCuentaId"))),
                                    SubCuenta = new BE.SubCuenta
                                    {
                                        SubCuentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SubCuentaId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("SubCuenta"))
                                    }
                                };

                                lst.Add(obj2);
                            }
                        }
                    }
                }
            }

            return lst;
        }

        public List<BE.SubCuenta> ObtenerSubCuentasPorCuenta(BE.Cuenta obj)
        {
            List<BE.SubCuenta> lst = null;

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Administracion_spSelSubCuentasPorCuenta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_Cuenta", MySqlDbType.VarChar, obj.Descripcion.Length).Value = obj.Descripcion;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            lst = new List<BE.SubCuenta>();
                            while (dr.Read())
                            {
                                BE.SubCuenta obj2 = new BE.SubCuenta
                                {
                                    SubCuentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SubCuentaId"))),
                                    Descripcion = dr.GetString(dr.GetOrdinal("SubCuenta")),
                                    CuentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("CuentaId"))),
                                    Cuenta = new BE.Cuenta
                                    {
                                        CuentaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("CuentaId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Cuenta"))
                                    }
                                };

                                lst.Add(obj2);
                            }
                        }
                    }
                }
            }

            return lst;
        }
    }
}
