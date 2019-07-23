using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Data.Database
{
    public class Adapter
    {
        const string consKeyDefaultCnnString = "ConnStringExpress";
        protected SqlConnection sqlConn = new SqlConnection();
        protected void OpenConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            if(sqlConn != null)
            {
                sqlConn.Close();
                sqlConn = null;
            }
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
