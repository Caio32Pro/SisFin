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
        public static MySqlConnection SqlCon = new MySqlConnection();

        public static void getConnection()
        {
            /*SqlConnection con = null;
            try
            {
                String conString = ConfigurationManager.
                                        ConnectionStrings["ConnectionString"].
                                        ConnectionString;
                con = new SqlConnection(conString);
                con.Open();
                SqlCommand cm = new SqlCommand("Select * from professor", con);
                SqlDataReader dataReader = cm.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader["matricula"] + "-" + dataReader["nome"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, algo deu errado!\n" + e);
            }
            finally
            {
                Console.WriteLine("\n\nAperte qualquer tecla para fechar!");
                Console.ReadKey();
            }*/
        }

    }
}
