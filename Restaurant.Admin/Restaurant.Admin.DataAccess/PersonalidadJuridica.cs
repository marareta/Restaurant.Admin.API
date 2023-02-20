using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class PersonalidadJuridica : Base
    {
        public List<BE.PersonalidadJuridica> ObtenerPersonalidadesJuridicasActivas()
        {
            List<BE.PersonalidadJuridica> lst = null;

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Catalogo_spSelPersonalidadJuridicaActivo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("_TipoObjeto", MySqlDbType.VarChar, obj.Descripcion.Length).Value = obj.Descripcion;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            lst = new List<BE.PersonalidadJuridica>();
                            while (dr.Read())
                            {
                                BE.PersonalidadJuridica obj2 = new BE.PersonalidadJuridica
                                {
                                    PersonalidadJuridicaId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("PersonalidadJuridicaId"))),
                                    Descripcion = dr.GetString(dr.GetOrdinal("PersonalidadJuridica")),
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
