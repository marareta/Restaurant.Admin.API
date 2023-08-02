using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public  class Log : Base
    {
        public void GuardarLog(BE.Log obj)
        {
            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Log_spInsLog", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_TipoLog", MySqlDbType.String, obj.TipoLog.Descripcion.Length).Value = obj.TipoLog.Descripcion;
                    cmd.Parameters.Add("_Log", MySqlDbType.VarChar, obj.LogDescripcion.Length).Value = obj.LogDescripcion;
                    cmd.Parameters.Add("_Response", MySqlDbType.VarChar, obj.Response.Length).Value = obj.Response;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        
                    }
                }
            }
        }
    }
}
