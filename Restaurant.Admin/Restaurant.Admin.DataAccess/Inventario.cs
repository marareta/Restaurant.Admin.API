using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Inventario : Base
    {
        public BE.Inventario GuardarInventario(BE.Inventario obj)
        {
            BE.Inventario retorno = new BE.Inventario();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Inventario_spInsInventario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_InventarioId", MySqlDbType.Int32, 12).Value = obj.InventarioId;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;
                    cmd.Parameters.Add("_Descripcion", MySqlDbType.VarChar, obj.Descripcion.Length).Value = obj.Descripcion;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Inventario
                                {
                                    InventarioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("InventarioId"))),
                                    SucursalId = obj.SucursalId
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public BE.Inventario ObtenerInventario(BE.Inventario obj)
        {
            BE.Inventario retorno = new BE.Inventario();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Inventario_spSelInventario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_InventarioId", MySqlDbType.Int32, 12).Value = obj.InventarioId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Inventario
                                {
                                    InventarioId = obj.InventarioId,
                                    UsuarioId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UsuarioId"))),
                                    SucursalId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("SucursalId"))),
                                    Fecha = Convert.ToDateTime(dr.GetDateTime(dr.GetOrdinal("Fecha"))),
                                    Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public void GuardarInventarioIngrediente(BE.InventarioIngrediente obj, BE.Inventario inv)
        {
            BE.Inventario retorno = new BE.Inventario();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Inventario_spInsInventarioIngrediente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_InventarioId", MySqlDbType.Int32, 12).Value = inv.InventarioId;
                    cmd.Parameters.Add("_IngredienteId", MySqlDbType.Int32, 12).Value = obj.IngredienteId;
                    cmd.Parameters.Add("_Cantidad", MySqlDbType.Decimal, 12).Value = obj.Cantidad;
                    cmd.Parameters.Add("_ExistenciaAnterior", MySqlDbType.Decimal, 12).Value = obj.Ingrediente.IngredienteStock.Stock;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = inv.SucursalId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {

                        }
                    }
                }
            }
        }
    }
}
