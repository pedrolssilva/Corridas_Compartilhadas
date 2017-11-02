using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pedro_teste.Models
{
    public class Sql
    {
        public static SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection("Server=tcp:pedrolssilva.database.windows.net,1433;Initial Catalog=pl;Persist Security Info=False;User ID=pedrolssilva;Password=123Mudar;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            conn.Open();

            return conn;
        }

    }
}