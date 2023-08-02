using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Ingrediente : Base
    {
        public List<BE.InventarioIngrediente> ObtenerIngredientesActivos(BE.Sucursal obj)
        {
            List<BE.InventarioIngrediente> lst = null;

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spSelObtenerIngredientesParaInventarioActivos", cn))
                {
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            lst = new List<BE.InventarioIngrediente>();
                            while (dr.Read())
                            {
                                BE.InventarioIngrediente obj2 = new BE.InventarioIngrediente
                                {
                                    Ingrediente =  new BE.Ingrediente
                                    {
                                        IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Ingrediente")),
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Estatus = new BE.Estatus
                                        {
                                            EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                            Descripcion = dr.GetString(dr.GetOrdinal("Estatus"))
                                        },
                                        InventarioIngredienteMinimo = new BE.InventarioIngredienteMinimo
                                        {
                                            IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId"))),
                                            Minimo = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Minimo")))
                                        },
                                        IngredienteUnidad = new BE.IngredienteUnidad
                                        {
                                            UnidadId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UnidadId"))),
                                            Unidad = new BE.Unidad
                                            {
                                                UnidadId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UnidadId"))),
                                                Descripcion = dr.GetString(dr.GetOrdinal("Unidad"))
                                            }
                                        },
                                        IngredienteStock = new BE.IngredienteStock
                                        {
                                            IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId"))),
                                            Stock = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Stock")))
                                        }
                                    },
                                    IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId")))
                                };

                                lst.Add(obj2);
                            }
                        }
                    }
                }
            }

            return lst;
        }

        public List<BE.Ingrediente> ObtenerIngredientes()
        {
            List<BE.Ingrediente> lst = null;

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spSelIngredientes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            lst = new List<BE.Ingrediente>();
                            while (dr.Read())
                            {
                                BE.Ingrediente obj2 = new BE.Ingrediente
                                {
                                    IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId"))),
                                    Descripcion = dr.GetString(dr.GetOrdinal("Ingrediente")),
                                    EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                    Estatus = new BE.Estatus
                                    {
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Estatus"))
                                    },
                                    InventarioIngredienteMinimo = new BE.InventarioIngredienteMinimo
                                    {
                                        IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId"))),
                                        Minimo = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Minimo")))
                                    },
                                    IngredienteUnidad = new BE.IngredienteUnidad
                                    {
                                        UnidadId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UnidadId"))),
                                        Unidad = new BE.Unidad
                                        {
                                            UnidadId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UnidadId"))),
                                            Descripcion = dr.GetString(dr.GetOrdinal("Unidad"))
                                        }
                                    },
                                    AplicaInventario = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("AplicaInventario"))),
                                    Porcion = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Porcion"))),
                                    Costo = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Costo")))
                                };

                                lst.Add(obj2);
                            }
                        }
                    }
                }
            }

            return lst;
        }

        public BE.Ingrediente ObtenerIngredientePorId(BE.Ingrediente obj)
        {
            BE.Ingrediente retorno = new BE.Ingrediente();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spSelIngredientePorId", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_IngredienteId", MySqlDbType.Int32, 12).Value = obj.IngredienteId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Ingrediente
                                {
                                    IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId"))),
                                    Descripcion = dr.GetString(dr.GetOrdinal("Ingrediente")),
                                    EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                    Costo = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Costo"))),
                                    Estatus = new BE.Estatus
                                    {
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Estatus"))
                                    },
                                    InventarioIngredienteMinimo = new BE.InventarioIngredienteMinimo
                                    {
                                        IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId"))),
                                        Minimo = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Minimo")))
                                    },
                                    IngredienteUnidad = new BE.IngredienteUnidad
                                    {
                                        UnidadId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UnidadId"))),
                                        Unidad = new BE.Unidad
                                        {
                                            UnidadId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UnidadId"))),
                                            Descripcion = dr.GetString(dr.GetOrdinal("Unidad"))
                                        }
                                    },
                                    AplicaInventario = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("AplicaInventario"))),
                                    Porcion = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Porcion")))
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public List<BE.EntradaIngrediente> ObtenerEntradaIngredientesActivos()
        {
            List<BE.EntradaIngrediente> lst = null;

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spSelObtenerIngredientesEntradasActivos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            lst = new List<BE.EntradaIngrediente>();
                            while (dr.Read())
                            {
                                BE.EntradaIngrediente obj2 = new BE.EntradaIngrediente
                                {
                                    Ingrediente = new BE.Ingrediente
                                    {
                                        IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Ingrediente")),
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Estatus = new BE.Estatus
                                        {
                                            EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                            Descripcion = dr.GetString(dr.GetOrdinal("Estatus"))
                                        },
                                        IngredienteUnidad = new BE.IngredienteUnidad
                                        {
                                            UnidadId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UnidadId"))),
                                            Unidad = new BE.Unidad
                                            {
                                                UnidadId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UnidadId"))),
                                                Descripcion = dr.GetString(dr.GetOrdinal("Unidad"))
                                            }
                                        }
                                    },
                                    IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId")))
                                };

                                lst.Add(obj2);
                            }
                        }
                    }
                }
            }

            return lst;
        }

        public BE.Ingrediente GuardarIngrediente(BE.Ingrediente obj)
        {
            BE.Ingrediente retorno = new BE.Ingrediente();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spInsIngrediente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_IngredienteId", MySqlDbType.Int32, 12).Value = obj.IngredienteId;
                    cmd.Parameters.Add("_Descripcion", MySqlDbType.VarChar, obj.Descripcion.Length).Value = obj.Descripcion;
                    cmd.Parameters.Add("_EstatusId", MySqlDbType.Int32, 12).Value = obj.EstatusId;
                    cmd.Parameters.Add("_Minimo", MySqlDbType.Decimal, 12).Value = obj.InventarioIngredienteMinimo.Minimo;
                    cmd.Parameters.Add("_AplicaInventario", MySqlDbType.Int32, 12).Value = obj.AplicaInventario;
                    cmd.Parameters.Add("_UnidadId", MySqlDbType.Int32, 12).Value = obj.IngredienteUnidad.UnidadId;
                    cmd.Parameters.Add("_Porcion", MySqlDbType.Decimal, 12).Value = obj.Porcion;
                    cmd.Parameters.Add("_Costo", MySqlDbType.Decimal, 12).Value = obj.Costo;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Ingrediente
                                {
                                    IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId")))
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
