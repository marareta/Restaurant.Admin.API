using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Modulo : Base
    {
        public List<BE.UsuarioSubModulo> ObtenerSubModulosPorUsuario(BE.Usuario usuario)
        {
            List<BE.UsuarioSubModulo> lst = new List<BE.UsuarioSubModulo>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spSelSubModulosPorUsuario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = usuario.UsuarioId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.UsuarioSubModulo tmp = new BE.UsuarioSubModulo
                                {
                                    SubModuloId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SubModuloId"))),
                                    SubModulo = new BE.SubModulo
                                    {
                                        SubModuloId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SubModuloId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("SubModulo")),
                                        Acceso = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("Acceso"))),
                                        ModuloId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ModuloId"))),
                                        Modulo = new BE.Modulo
                                        {
                                            ModuloId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ModuloId"))),
                                            Descripcion = dr.GetString(dr.GetOrdinal("Modulo")),
                                        }
                                    }
                                };

                                lst.Add(tmp);
                            }
                        }
                    }
                }

            }
            return lst;
        }

        public List<BE.Modulo> ObtenerModulos()
        {
            List<BE.Modulo> lst = new List<BE.Modulo>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spSelModulos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.Modulo tmp = new BE.Modulo
                                {
                                    ModuloId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ModuloId"))),
                                    Descripcion = dr.GetString(dr.GetOrdinal("Modulo"))
                                };
                                lst.Add(tmp);
                            }
                        }
                    }
                }
            }
            return lst;
        }

        public List<BE.SubModulo> ObtenerSubModulos(BE.Modulo obj, BE.Usuario usuario)
        {
            List<BE.SubModulo> lst = new List<BE.SubModulo>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spSelSubModulos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_ModuloId", MySqlDbType.Int32, 12).Value = obj.ModuloId;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = usuario.UsuarioId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.SubModulo tmp = new BE.SubModulo
                                {
                                    SubModuloId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SubModuloId"))),
                                    Descripcion = dr.GetString(dr.GetOrdinal("SubModulo")),
                                    Acceso = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("Acceso")))
                                };
                                lst.Add(tmp);
                            }
                        }
                    }
                }

            }
            return lst;
        }

        public void GuardarUsuarioSubModulo(BE.UsuarioSubModulo obj)
        {
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Seguridad_spInsUsuarioSubModulo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_SubModuloId", MySqlDbType.Int32, 12).Value = obj.SubModuloId;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;
                    cmd.Parameters.Add("_Acceso", MySqlDbType.Int32, 12).Value = obj.SubModulo.Acceso;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {

                    }
                }



            }
        }
    }
}
