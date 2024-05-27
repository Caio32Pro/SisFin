using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Connection
    {
        public static String conString = ConfigurationManager.ConnectionStrings["cnStrMysql"].ConnectionString;
        public static MySqlConnection SqlCon = new MySqlConnection(conString);

        public static MySqlConnection getConnection()
        {
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["cnStrMysql"].ConnectionString;
                if (Connection.SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    MySqlConnection SqlCon = new MySqlConnection(conString);
                }
                return SqlCon;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
