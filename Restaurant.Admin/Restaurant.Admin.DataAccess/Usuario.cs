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

        public List<BE.Usuario> ObtenerUsuariosBusqueda(BE.UsuarioCredenciales obj)
        {
            List<BE.Usuario> retorno = new List<BE.Usuario>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spSelUsuariosBusqueda", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_Busqueda", MySqlDbType.VarChar, obj.NombreUsuario.Length).Value = obj.NombreUsuario;

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
                                BE.Usuario tmp = new BE.Usuario
                                {
                                    UsuarioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UsuarioId"))),
                                    EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                    Estatus = new BE.Estatus
                                    {
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Estatus"))
                                    },
                                    UsuarioDatosGenerales = new BE.UsuarioDatosGenerales
                                    {
                                        Nombres = dr.GetString(dr.GetOrdinal("Nombre")),
                                        ApellidoPaterno = dr.GetString(dr.GetOrdinal("ApellidoPaterno")),
                                        ApellidoMaterno = dr.GetString(dr.GetOrdinal("ApellidoMaterno"))
                                    },
                                    UsuarioCredenciales = new BE.UsuarioCredenciales
                                    {
                                        NombreUsuario = dr.GetString(dr.GetOrdinal("NombreUsuario")),
                                        Password = dr.GetString(dr.GetOrdinal("Password"))
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

        public List<BE.Usuario> ObtenerUsuariosParaSincronizacionConSucursal(BE.Sucursal obj)
        {
            List<BE.Usuario> retorno = new List<BE.Usuario>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spSelUsuariosPorSucursal", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;

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
                                BE.Usuario tmp = new BE.Usuario
                                {
                                    UsuarioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UsuarioId"))),
                                    EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                    Estatus = new BE.Estatus
                                    {
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Estatus"))
                                    },
                                    UsuarioDatosGenerales = new BE.UsuarioDatosGenerales
                                    {
                                        Nombres = dr.GetString(dr.GetOrdinal("Nombre")),
                                        ApellidoPaterno = dr.GetString(dr.GetOrdinal("ApellidoPaterno")),
                                        ApellidoMaterno = dr.GetString(dr.GetOrdinal("ApellidoMaterno"))
                                    },
                                    UsuarioCredenciales = new BE.UsuarioCredenciales
                                    {
                                        NombreUsuario = dr.GetString(dr.GetOrdinal("NombreUsuario")),
                                        Password = dr.GetString(dr.GetOrdinal("Password"))
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

        public List<BE.UsuarioSucursal> ObtenerUsuariosSucursales(BE.Usuario obj)
        {
            List<BE.UsuarioSucursal> retorno = new List<BE.UsuarioSucursal>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spSelUsuarioSucursales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        //msj = par1.Value == null ? "" : par1.Value.ToString();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.UsuarioSucursal tmp = new BE.UsuarioSucursal
                                {
                                    UsuarioId = obj.UsuarioId,
                                    SucursalId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SucursalId"))),
                                    Sucursal = new BE.Sucursal
                                    {
                                        SucursalId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SucursalId"))),
                                        Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                        Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                                        MunicipioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("MunicipioId"))),
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId")))
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

        public BE.UsuarioCredenciales ValidarUsuarioExistente(BE.Usuario usuario)
        {
            BE.UsuarioCredenciales retorno = new BE.UsuarioCredenciales();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spSelValidaUsuarioExistente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 8).Value = usuario.UsuarioId;
                    cmd.Parameters.Add("_NombreUsuario", MySqlDbType.VarChar, usuario.UsuarioCredenciales.NombreUsuario.Length).Value = usuario.UsuarioCredenciales.NombreUsuario;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno.NombreUsuario = dr.GetString(dr.GetOrdinal("Retorno"));
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public BE.Usuario GuardarUsuario(BE.Usuario obj)
        {
            BE.Usuario retorno = new BE.Usuario();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spInsUsuario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;
                    cmd.Parameters.Add("_EstatusId", MySqlDbType.Int32, 12).Value = obj.EstatusId;
                    cmd.Parameters.Add("_NombreUsuario", MySqlDbType.VarChar, obj.UsuarioCredenciales.NombreUsuario.Length).Value = obj.UsuarioCredenciales.NombreUsuario;
                    cmd.Parameters.Add("_Password", MySqlDbType.VarChar, obj.UsuarioCredenciales.Password.Length).Value = obj.UsuarioCredenciales.Password;
                    cmd.Parameters.Add("_Nombres", MySqlDbType.VarChar, obj.UsuarioDatosGenerales.Nombres.Length).Value = obj.UsuarioDatosGenerales.Nombres;
                    cmd.Parameters.Add("_ApellidoPaterno", MySqlDbType.VarChar, obj.UsuarioDatosGenerales.ApellidoPaterno.Length).Value = obj.UsuarioDatosGenerales.ApellidoPaterno;
                    cmd.Parameters.Add("_ApellidoMaterno", MySqlDbType.VarChar, obj.UsuarioDatosGenerales.ApellidoMaterno.Length).Value = obj.UsuarioDatosGenerales.ApellidoMaterno;

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
                                retorno = new BE.Usuario
                                {
                                    UsuarioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UsuarioId")))
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public void EliminaUsuarioSucursal(BE.Usuario obj)
        {
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spDelUsuarioSucursales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                    
                    }
                }
            }
        }

        public void GuardaUsuarioSucursal(BE.UsuarioSucursal obj, BE.Usuario usuario)
        {
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spInsUsuarioSucursal", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = usuario.UsuarioId;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {

                    }
                }
            }
        }
    }
}
