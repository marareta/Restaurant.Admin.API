using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Usuario : Base
    {
        public BE.UsuarioCredenciales ValidaUsuarioPassword(BE.UsuarioCredenciales credenciales)
        {
            BE.UsuarioCredenciales usu = null;

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spSelUsuarioPassword", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_NombreUsuario", MySqlDbType.VarChar, credenciales.NombreUsuario.Length).Value = credenciales.NombreUsuario;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                usu = new BE.UsuarioCredenciales
                                {
                                    UsuarioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UsuarioId"))),
                                    Password = dr.GetString(dr.GetOrdinal("Password"))
                                };
                            }
                        }
                    }
                }
            }

            return usu;
        }

        public BE.Usuario ValidaUsuarioLogin(BE.UsuarioCredenciales credenciales)
        {
            BE.Usuario usu = null;

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spSelUsuarioLogin", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_NombreUsuario", MySqlDbType.VarChar, credenciales.NombreUsuario.Length).Value = credenciales.NombreUsuario;
                    cmd.Parameters.Add("_Password", MySqlDbType.VarChar, credenciales.Password.Length).Value = credenciales.Password;

                    //SqlParameter par1 = new SqlParameter { ParameterName = "_Msj", Value = string.Empty, SqlDbType = MySqlDbType.VarChar, Size = 800, Direction = ParameterDirection.Output };
                    //cmd.Parameters.Add(par1);

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        //msj = par1.Value == null ? "" : par1.Value.ToString();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                usu = new BE.Usuario();
                                BE.Estatus est = new BE.Estatus();
                                est.EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId")));
                                est.Descripcion = dr.GetString(dr.GetOrdinal("Estatus"));

                                usu.UsuarioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UsuarioId")));
                                usu.EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId")));
                                usu.Estatus = est;
                            }
                        }
                    }
                }
            }

            return usu;
        }

        public BE.UsuarioDatosGenerales ObtenerUsuarioDatosGenerales(BE.Usuario usuario)
        {
            BE.UsuarioDatosGenerales obj = null;

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spSelUsuarioDatosGenerales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 8).Value = usuario.UsuarioId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                obj = new BE.UsuarioDatosGenerales
                                {
                                    Nombres = dr.GetString(dr.GetOrdinal("Nombre")),
                                    ApellidoPaterno = dr.GetString(dr.GetOrdinal("ApellidoPaterno")),
                                    ApellidoMaterno = dr.GetString(dr.GetOrdinal("ApellidoMaterno")),
                                };
                            }
                        }
                    }
                }
            }

            return obj;
        }

        public string ValidarUsuarioEstatusLogin(BE.Usuario usuario)
        {
            string retorno = "";

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spSelValidarUsuarioEstatusLogin", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 16).Value = usuario.UsuarioId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = dr.GetString(dr.GetOrdinal("Mensaje"));
                            }
                        }
                    }
                }
            }

            return retorno;
        }
    }
}
