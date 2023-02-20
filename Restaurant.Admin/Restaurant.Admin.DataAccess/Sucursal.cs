using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Sucursal : Base
    {
        public BE.Sucursal ObtenerSucursal()
        {
            BE.Sucursal retorno = new BE.Sucursal();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Sucursal_spSelSucursal", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Sucursal
                                {
                                    SucursalId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SucursalId"))),
                                    Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                    Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                                    MunicipioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("MunicipioId"))),
                                    Municipio = new BE.Municipio
                                    {
                                        MunicipioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("MunicipioId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Municipio")),
                                        EstadoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstadoId"))),
                                        Estado = new BE.Estado
                                        {
                                            EstadoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstadoId"))),
                                            Descripcion = dr.GetString(dr.GetOrdinal("Estado")),
                                            PaisId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("PaisId"))),
                                            Pais = new BE.Pais
                                            {
                                                PaisId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("PaisId"))),
                                                Descripcion = dr.GetString(dr.GetOrdinal("Pais"))
                                            }
                                        }
                                    },
                                    EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                    Estatus = new BE.Estatus
                                    {
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Estatus"))
                                    }
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public List<BE.Sucursal> ObtenerSucursales()
        {
            List<BE.Sucursal> retorno = new List<BE.Sucursal>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spSelSucursales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.Sucursal tmp = new BE.Sucursal
                                {
                                    SucursalId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SucursalId"))),
                                    Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                    Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                                    MunicipioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("MunicipioId"))),
                                    Municipio = new BE.Municipio
                                    {
                                        MunicipioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("MunicipioId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Municipio")),
                                        EstadoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstadoId"))),
                                        Estado = new BE.Estado
                                        {
                                            EstadoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstadoId"))),
                                            Descripcion = dr.GetString(dr.GetOrdinal("Estado")),
                                            PaisId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("PaisId"))),
                                            Pais = new BE.Pais
                                            {
                                                PaisId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("PaisId"))),
                                                Descripcion = dr.GetString(dr.GetOrdinal("Pais"))
                                            }
                                        }
                                    },
                                    EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                    Estatus = new BE.Estatus
                                    {
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Estatus"))
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
