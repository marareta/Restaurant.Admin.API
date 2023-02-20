using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Estatus : Base
    {
        public List<BE.Estatus> ObtenerEstatusPorTipoObjeto(BE.TipoObjeto obj)
        {
            List<BE.Estatus> lst = null;

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spSelEstatusPorTipoDeObjeto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_TipoObjeto", MySqlDbType.VarChar, obj.Descripcion.Length).Value = obj.Descripcion;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            lst = new List<BE.Estatus>();
                            while (dr.Read())
                            {
                                BE.Estatus obj2 = new BE.Estatus();
                                obj2.EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId")));
                                obj2.Descripcion = dr.GetString(dr.GetOrdinal("Estatus"));

                                lst.Add(obj2);
                            }
                        }
                    }
                }
            }

            return lst;
        }
    }
}
