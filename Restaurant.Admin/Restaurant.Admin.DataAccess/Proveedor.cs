using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Proveedor : Base
    {
        public List<BE.Proveedor> BuscarProveedoresPorNombre(string obj)
        {
            List<BE.Proveedor> retorno = new List<BE.Proveedor>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Proveedor_spSelProveedoresPorNombre", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_Palabra", MySqlDbType.VarChar, obj.Length).Value = obj;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.Proveedor tmp = new BE.Proveedor
                                {
                                    ProveedorId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProveedorId"))),
                                    EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                    Estatus = new BE.Estatus
                                    {
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Estatus"))
                                    },
                                    Nombre = dr.GetString(dr.GetOrdinal("Proveedor")),
                                    PersonalidadJuridicaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("PersonalidadJuridicaId"))),
                                    PersonalidadJuridica = new BE.PersonalidadJuridica
                                    {
                                        PersonalidadJuridicaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("PersonalidadJuridicaId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("PersonalidadJuridica"))
                                    },
                                    RFC = dr.GetString(dr.GetOrdinal("RFC")),
                                    Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                                    CP = dr.GetString(dr.GetOrdinal("CP"))
                                };

                                retorno.Add(tmp);
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public BE.Proveedor ObtenerProveedorPorId(BE.Proveedor obj)
        {
            BE.Proveedor retorno = new BE.Proveedor();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Proveedor_spSelProveedorPorId", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_ProveedorId", MySqlDbType.Int32, 12).Value = obj.ProveedorId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Proveedor
                                {
                                    ProveedorId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProveedorId"))),
                                    EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                    Estatus = new BE.Estatus
                                    {
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Estatus"))
                                    },
                                    Nombre = dr.GetString(dr.GetOrdinal("Proveedor")),
                                    PersonalidadJuridicaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("PersonalidadJuridicaId"))),
                                    PersonalidadJuridica = new BE.PersonalidadJuridica
                                    {
                                        PersonalidadJuridicaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("PersonalidadJuridicaId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("PersonalidadJuridica")),
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusIdPersonalidadJuridica"))),
                                        Estatus = new BE.Estatus
                                        {
                                            EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusIdPersonalidadJuridica"))),
                                            Descripcion = dr.GetString(dr.GetOrdinal("EstatusPersonalidadJuridica"))
                                        },
                                    },
                                    RFC = dr.GetString(dr.GetOrdinal("RFC")),
                                    Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                                    CP = dr.GetString(dr.GetOrdinal("CP"))
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public BE.Proveedor ObtenerProveedorPorRFC(BE.Proveedor obj)
        {
            BE.Proveedor retorno = new BE.Proveedor();
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Proveedor_spSelProveedorPorRFC", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_RFC", MySqlDbType.VarChar, obj.RFC.Length).Value = obj.RFC;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                retorno = new BE.Proveedor { 
                                    ProveedorId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProveedorId"))),
                                    EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                    Estatus = new BE.Estatus
                                    {
                                        Descripcion = dr.GetString(dr.GetOrdinal("Estatus")),
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId")))
                                    },
                                    Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                    PersonalidadJuridicaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("PersonalidadJuridicaId"))),
                                    PersonalidadJuridica = new BE.PersonalidadJuridica
                                    {
                                        PersonalidadJuridicaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("PersonalidadJuridicaId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("PersonalidadJuridica"))
                                    },
                                    RFC = dr.GetString(dr.GetOrdinal("RFC")),
                                    Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                                    CP = dr.GetString(dr.GetOrdinal("CP"))
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public BE.Proveedor GuardarProveedor(BE.Proveedor obj)
        {
            BE.Proveedor retorno = new BE.Proveedor();
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Proveedor_spInsProveedor", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_ProveedorId", MySqlDbType.Int32, 12).Value = obj.ProveedorId;
                    cmd.Parameters.Add("_EstatusId", MySqlDbType.Int32, 12).Value = obj.EstatusId;
                    cmd.Parameters.Add("_Nombre", MySqlDbType.VarChar, obj.Nombre.Length).Value = obj.Nombre;
                    cmd.Parameters.Add("_PersonalidadJuridicaId", MySqlDbType.Int32, 12).Value = obj.PersonalidadJuridicaId;
                    cmd.Parameters.Add("_RFC", MySqlDbType.VarChar, obj.RFC.Length).Value = obj.RFC;
                    cmd.Parameters.Add("_Direccion", MySqlDbType.VarChar, obj.Direccion.Length).Value = obj.Direccion;
                    cmd.Parameters.Add("_CP", MySqlDbType.VarChar, obj.CP.Length).Value = obj.CP;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                retorno = new BE.Proveedor
                                {
                                    ProveedorId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProveedorId"))),
                                    RFC = obj.RFC
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }
    }
}
