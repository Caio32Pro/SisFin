using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using MySql.Data.MySqlClient;

namespace Negocio
{
    public class ClienteService
    {
        private ClienteRepository _repository;

        public ClienteService()
        {
            _repository = new ClienteRepository();
        }

        public string Update(int? id, TipoPessoa tipoPessoa, string nome, string email)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado

            var cliente = new Cliente
            {
                Id = id,
                tipoPessoa = tipoPessoa,
                Nome = nome,
                Email = email
            };

            if (id == null)
                return _repository.Insert(cliente);
            else
                return _repository.Update(cliente);

        }

        public string  Insert(Cliente cliente)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado

            return _repository.Insert(cliente);

        }

        public DataTable getAll()
        {
            DataTable DtResultado = new DataTable("cliente");
            try
            {
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();
                String sqlSelect = "select * from cliente";

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
