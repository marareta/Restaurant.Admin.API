using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Traspaso : Base
    {
        public BE.Traspaso GuardarTraspaso(BE.Traspaso obj)
        {
            BE.Traspaso retorno = new BE.Traspaso();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Inventario_spInsTraspaso", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_TraspasoId", MySqlDbType.Int32, 12).Value = obj.TraspasoId;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;
                    cmd.Parameters.Add("_SucursalOrigenId", MySqlDbType.Int32, 12).Value = obj.SucursalOrigenId;
                    cmd.Parameters.Add("_SucursalDestinoId", MySqlDbType.Int32, 12).Value = obj.SucursalDestinoId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Traspaso
                                {
                                    TraspasoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("TraspasoId"))),
                                    SucursalOrigenId = obj.SucursalOrigenId,
                                    SucursalDestinoId = obj.SucursalDestinoId
                                };
                            }
                        }
                    }
                }
            }

            return retorno;
        }

        public void GuardarTraspasoIngrediente(BE.TraspasoIngrediente obj, BE.Traspaso inv)
        {
            BE.Traspaso retorno = new BE.Traspaso();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Inventario_spInsTraspasoIngrediente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_TraspasoId", MySqlDbType.Int32, 12).Value = inv.TraspasoId;
                    cmd.Parameters.Add("_IngredienteId", MySqlDbType.Int32, 12).Value = obj.IngredienteId;
                    cmd.Parameters.Add("_Cantidad", MySqlDbType.Decimal, 12).Value = obj.Cantidad;
                    cmd.Parameters.Add("_SucursalOrigenId", MySqlDbType.Int32, 12).Value = inv.SucursalOrigenId;
                    cmd.Parameters.Add("_SucursalDestinoId", MySqlDbType.Int32, 12).Value = inv.SucursalDestinoId;

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
