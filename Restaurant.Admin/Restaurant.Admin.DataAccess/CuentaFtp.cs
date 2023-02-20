using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class CuentaFtp : Base
    {
        public BE.CuentaFtp ObtenerCuentaFtp(BE.CuentaFtp cuenta)
        {
            BE.CuentaFtp retorno = new BE.CuentaFtp();
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spSelCuentaFtp", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_Nombre", MySqlDbType.VarChar, cuenta.Nombre.Length).Value = cuenta.Nombre;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                retorno.CuentaFtpId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("CuentaFtpId")));
                                retorno.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                                retorno.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"));
                                retorno.Servidor = dr.GetString(dr.GetOrdinal("Servidor"));
                                retorno.Usuario = dr.GetString(dr.GetOrdinal("Usuario"));
                                retorno.Password = dr.GetString(dr.GetOrdinal("Password"));
                            }
                        }
                    }
                }
            }

            return retorno;
        }
    }
}
