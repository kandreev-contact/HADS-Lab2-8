
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

/// <summary>
/// La capa de accesso a datos contiene toda la informacion relacionada con la base de datos.
/// </summary>
namespace DataAccessLayer
{
    public class GeneralDAO
    {
        private SqlConnection connection = new SqlConnection();
        private SqlCommand sqlCommand = new SqlCommand();
        private String connectionString;

        public GeneralDAO()
        {
            this.connectionString = "Data Source=tcp:hads22-12.database.windows.net,1433;Initial Catalog=HADS22-12;User ID=kandreev001@ikasle.ehu.eus@hads22-12;Password=HADS22-12";
        }

        public void openConection()
        {
            try
            {
                connection.ConnectionString = connectionString;
                connection.Open();

            }
            catch (Exception ex)
            {
                throw new Exception("Database connection error! " + ex.ToString());
            }
        }

        public void closeConnection()
        {
            connection.Close();
        }

        public SqlConnection getConnection()
        {
            return this.connection;
        }
    }
}
