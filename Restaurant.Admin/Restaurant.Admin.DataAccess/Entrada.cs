using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Entrada : Base
    {
        public BE.Entrada GuardarEntrada(BE.Entrada obj)
        {
            BE.Entrada retorno = new BE.Entrada();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Sucursal_spInsEntrada", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_EntradaId", MySqlDbType.Int32, 12).Value = obj.EntradaId;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;
                    cmd.Parameters.Add("_Descripcion", MySqlDbType.VarChar, obj.Descripcion.Length).Value = obj.Descripcion;
                    cmd.Parameters.Add("_ProveedorId", MySqlDbType.Int32, 12).Value = obj.ProveedorId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Entrada
                                {
                                    EntradaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EntradaId"))),
                                    SucursalId = obj.SucursalId
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public void GuardarEntradaIngrediente(BE.EntradaIngrediente obj, BE.Entrada inv)
        {
            BE.Entrada retorno = new BE.Entrada();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Sucursal_spInsEntradaIngrediente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_EntradaId", MySqlDbType.Int32, 12).Value = inv.EntradaId;
                    cmd.Parameters.Add("_IngredienteId", MySqlDbType.Int32, 12).Value = obj.IngredienteId;
                    cmd.Parameters.Add("_Cantidad", MySqlDbType.Decimal, 12).Value = obj.Cantidad;
                    cmd.Parameters.Add("_Costo", MySqlDbType.Decimal, 12).Value = obj.Costo;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = inv.SucursalId;
                    cmd.Parameters.Add("_Presentacion", MySqlDbType.Decimal, 12).Value = obj.Presentacion;

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
