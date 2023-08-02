using MySql.Data.MySqlClient;
using Restaurant.Admin.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Producto: Base
    {
        public List<BE.Producto> ObtenerProductos()
        {
            List<BE.Producto> retorno = new List<BE.Producto>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Producto_spSelProductos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.DatoEntero1;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.Producto tmp = new BE.Producto
                                {
                                    ProductoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProductoId"))),
                                    DescripcionCorta = dr.GetString(dr.GetOrdinal("DescripcionCorta")),
                                    DescripcionLarga = dr.GetString(dr.GetOrdinal("DescripcionLarga")),
                                    EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                    EsCombo = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EsCombo"))),
                                    Estatus = new BE.Estatus
                                    {
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Estatus")),
                                    },
                                    ProductoPrecio = new ProductoPrecio
                                    {
                                        Precio = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Precio")))
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

        public BE.Producto ObtenerProductoPorId(BE.Producto obj)
        {
            BE.Producto retorno = new BE.Producto();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Producto_spSelProductoPorId", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_ProductoId", MySqlDbType.Int32, 12).Value = obj.ProductoId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Producto
                                {
                                    ProductoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ProductoId"))),
                                    DescripcionCorta = dr.GetString(dr.GetOrdinal("DescripcionCorta")),
                                    DescripcionLarga = dr.GetString(dr.GetOrdinal("DescripcionLarga")),
                                    EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                    EsCombo = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EsCombo"))),
                                    Estatus = new BE.Estatus
                                    {
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Estatus")),
                                    },
                                    ProductoPrecio = new ProductoPrecio
                                    {
                                        Precio = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Precio")))
                                    }
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public void GuardarProductoPrecio(BE.Producto obj)
        {
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Producto_spInsProductoPrecio", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_ProductoId", MySqlDbType.Int32, 12).Value = obj.ProductoId;
                    cmd.Parameters.Add("_Precio", MySqlDbType.Decimal, 12).Value = obj.ProductoPrecio.Precio;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        
                    }
                }
            }
        }

        public void EliminarProductoIngredientes(BE.Producto obj)
        {
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Producto_spDelProductoIngredientes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_ProductoId", MySqlDbType.Int32, 12).Value = obj.ProductoId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        
                    }
                }
            }
        }

        public void GuardarProductoIngrediente(BE.ProductoIngrediente obj)
        {
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Producto_spInsProductoIngrediente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_ProductoId", MySqlDbType.Int32, 12).Value = obj.ProductoId;
                    cmd.Parameters.Add("_IngredienteId", MySqlDbType.Int32, 12).Value = obj.IngredienteId;
                    cmd.Parameters.Add("_Cantidad", MySqlDbType.Decimal, 12).Value = obj.Cantidad;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {

                    }
                }
            }
        }

        public List<BE.ProductoIngrediente> ObtenerProductoIngredientes(BE.Producto obj)
        {
            List<BE.ProductoIngrediente> retorno = new List<BE.ProductoIngrediente>();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Producto_spSelProductoIngredientes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_ProductoId", MySqlDbType.Int32, 12).Value = obj.ProductoId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                BE.ProductoIngrediente tmp = new BE.ProductoIngrediente
                                {
                                    ProductoId = obj.ProductoId,
                                    //Producto = obj,
                                    Cantidad = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Cantidad"))),
                                    IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId"))),
                                    Ingrediente = new BE.Ingrediente {
                                        IngredienteId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("IngredienteId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Ingrediente")),
                                        Porcion = Convert.ToDecimal(dr.GetDecimal(dr.GetOrdinal("Porcion"))),
                                        IngredienteUnidad = new IngredienteUnidad
                                        {
                                            UnidadId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UnidadId"))),
                                            Unidad = new BE.Unidad
                                            {
                                                Descripcion = dr.GetString(dr.GetOrdinal("Unidad")),
                                            }
                                        }
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
