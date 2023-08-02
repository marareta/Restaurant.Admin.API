using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Admin.DataAccess
{
    public class Base
    {
        protected MySqlConnection connectionString { get; set; }

        public Base(string connection = "cnRestaurantAdmin")
        {
            connectionString = new MySqlConnection();

#if DEBUG
            connectionString.ConnectionString = "server=localhost;port=3307;database=ocacorra_tashimo_admin;user=root;password=root;";
            //connectionString.ConnectionString = "Data Source=198.38.83.224;Initial Catalog=ocacorra_sportandhealth;User ID=ocacorra_sportandhealth1;Password=SportAndHealth1;";// ConfigurationManager.AppSettings.Get(connection);
#else
            //connectionString.ConnectionString = "server=localhost;port=3306;database=sportandhealth;user=root;password=root;";
            connectionString.ConnectionString = "Data Source=204.93.167.23;Initial Catalog=ocacorra_tashimo_admin;User ID=ocacorra_tashimo;Password=tashimoadmin123;";// ConfigurationManager.AppSettings.Get(connection);
#endif
            //Server=tcp:petcare1.database.windows.net,1433;Initial Catalog=PetCare;Persist Security Info=False;User ID=PetCare;Password=Diciembre2019*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
            //string asas = OICG.Encrypt.EncryptString(@"Data Source=LAMXP-ELPT10176;Initial Catalog=PetCare;User Id=PetCare;Password=PetCare;", ConfigurationManager.AppSettings.Get("llave"));

            //string asasasa = OICG.Encrypt.EncryptString("Data Source=localhost;Initial Catalog=PetCare;Trusted_Connection=Yes;", ConfigurationManager.AppSettings.Get("llave"));
            //string asas = enc.Encriptar(@"Data Source=LAMXP-ELPT10176;Initial Catalog=PetCare;Trusted_Connection=Yes;");
        }
    }
}
