using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class FormaPago : Base
    {
        public List<BE.FormaPago> ObtenerFormasPagoPorTipoObjeto(BE.TipoObjeto obj)
        {
            List<BE.FormaPago> lst = null;

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spSelFormasPagoPorTipoObjeto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_TipoObjeto", MySqlDbType.VarChar, obj.Descripcion.Length).Value = obj.Descripcion;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            lst = new List<BE.FormaPago>();
                            while (dr.Read())
                            {
                                BE.FormaPago obj2 = new BE.FormaPago
                                {
                                    FormaPagoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("FormaPagoId"))),
                                    Descripcion = dr.GetString(dr.GetOrdinal("FormaPago")),
                                    AplicaReferencia = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("AplicaReferencia"))),
                                    EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                    Estatus = new BE.Estatus
                                    {
                                        EstatusId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("EstatusId"))),
                                        Descripcion = dr.GetString(dr.GetOrdinal("Estatus"))
                                    }
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
