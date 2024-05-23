using System;
using System.Collections.Generic;
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

                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = Connection.SqlCon,
                    CommandText = "INSERT INTO Cliente (nome, email) VALUES (@pNome, @pEmail) ",
                    CommandType = CommandType.Text
                };
                SqlCmd.Parameters.AddWithValue("pNome", cliente.Nome);
                SqlCmd.Parameters.AddWithValue("pEmail", cliente.Email);

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
                SqlCommand SqlCmd = new SqlCommand(updateSql, Connection.SqlCon);
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

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clientes;
        }

        public IList<Cliente> getAll()
        {
            return _clientes;
        }
    }
}
