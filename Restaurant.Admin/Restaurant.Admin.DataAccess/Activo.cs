using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BE = Restaurant.Admin.BusinessEntities;

namespace Restaurant.Admin.DataAccess
{
    public class Activo : Base
    {
        public BE.Activo GuardarActivo(BE.Activo obj)
        {
            BE.Activo retorno = new BE.Activo();

            using (MySqlConnection cn = new MySqlConnection(this.connectionString.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("Activo_spInsActivo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_ActivoId", MySqlDbType.Int32, 12).Value = obj.ActivoId;
                    cmd.Parameters.Add("_SubCuentaFinalId", MySqlDbType.Int32, 12).Value = obj.SubCuentaFinalId;
                    cmd.Parameters.Add("_Monto", MySqlDbType.Decimal, 12).Value = obj.Monto;
                    cmd.Parameters.Add("_Fecha", MySqlDbType.DateTime, 12).Value = obj.Fecha;
                    cmd.Parameters.Add("_Factura", MySqlDbType.VarChar, obj.Factura.Length).Value = obj.Factura;
                    cmd.Parameters.Add("_Descripcion", MySqlDbType.VarChar, obj.Descripcion.Length).Value = obj.Descripcion;
                    cmd.Parameters.Add("_UsuarioId", MySqlDbType.Int32, 12).Value = obj.UsuarioId;
                    cmd.Parameters.Add("_ProveedorId", MySqlDbType.Int32, 12).Value = obj.ActivoProveedor.ProveedorId;
                    cmd.Parameters.Add("_FormaPagoId", MySqlDbType.Int32, 12).Value = obj.FormaPagoId;
                    cmd.Parameters.Add("_SucursalId", MySqlDbType.Int32, 12).Value = obj.SucursalId;

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                retorno = new BE.Activo
                                {
                                    ActivoId = Convert.ToInt32(dr.GetInt32(dr.GetOrdinal("ActivoId")))
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
