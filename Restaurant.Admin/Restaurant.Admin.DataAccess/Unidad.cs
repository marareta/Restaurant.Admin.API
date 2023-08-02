using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Unidad : Base
    {
        public List<BE.Unidad> ObtenerUnidadesActivas()
        {
            List<BE.Unidad> lst = null;

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spSelUnidadesActivas", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("_TipoObjeto", MySqlDbType.VarChar, obj.Descripcion.Length).Value = obj.Descripcion;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            lst = new List<BE.Unidad>();
                            while (dr.Read())
                            {
                                BE.Unidad obj2 = new BE.Unidad
                                {
                                    UnidadId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("UnidadId"))),
                                    Descripcion = dr.GetString(dr.GetOrdinal("Unidad"))
                                };

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
