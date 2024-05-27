using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ClienteRepository
    {
        private IList<Cliente> _clientes = new List<Cliente>();

        public string Insert(Cliente cliente)
        {
            string resp = "";
            try
            {
                //codigo de inserção
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();

                MySqlCommand SqlCmd = new MySqlCommand
                {
                    Connection = Connection.SqlCon,
                    CommandText = "INSERT INTO cliente (nome, email, tipoPessoa) VALUES (@pNome, @pEmail, @pTipoPessoa) ",
                    CommandType = CommandType.Text
                };
                SqlCmd.Parameters.AddWithValue("pNome", cliente.Nome);
                SqlCmd.Parameters.AddWithValue("pEmail", cliente.Email);
                SqlCmd.Parameters.AddWithValue("pTipoPessoa", cliente.tipoPessoa);

                //executa o stored procedure
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "SUCESSO" : "FALHA";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (Connection.SqlCon.State == ConnectionState.Open)
                    Connection.SqlCon.Close();
            }
 
            return resp;
        }

        public string Update(Cliente cliente)
        {
            string resp = "";
            try
            {
                //codigo de inserção
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();

                string updateSql = String.Format("UPDATE Cliente SET " +
                                    "Nome = @pNome, email = @pEmail " +
                                    "WHERE id = @pId ");
                MySqlCommand SqlCmd = new MySqlCommand(updateSql, Connection.SqlCon);
                SqlCmd.Parameters.AddWithValue("pNome", cliente.Nome);
                SqlCmd.Parameters.AddWithValue("pEmail", cliente.Email);
                SqlCmd.Parameters.AddWithValue("pId", cliente.Id);

                //executa o stored procedure
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "SUCESSO" : "FALHA";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (Connection.SqlCon.State == ConnectionState.Open)
                    Connection.SqlCon.Close();
            }
            return resp;
        }

        public void Remove(Cliente cliente)
        {
            this._clientes.Remove(cliente);
        }

        public DataTable getAll()
        {
            DataTable DtResultado = new DataTable("cliente");
            try
            {
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();
                String sqlSelect = "select * from Cliente";

                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = sqlSelect;
                SqlCmd.CommandType = CommandType.Text;
                MySqlDataAdapter SqlData = new MySqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

    }
}
