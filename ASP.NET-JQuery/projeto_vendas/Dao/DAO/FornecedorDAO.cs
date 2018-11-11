using Dao.DAO;
using MySql.Data.MySqlClient;
using Objects.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Dao
{
    public class FornecedorDAO
    {
        public Fornecedor Inserir(Fornecedor f)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "INSERT INTO fornecedor(nome_fornecedor,nome_empresa, telefone_fornecedor)" +
                    " VALUES (@nome,@empresa,@telefone)";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@nome", f.Nome);
                command.Parameters.AddWithValue("@empresa", f.NomeEmpresa);
                command.Parameters.AddWithValue("@telefone", f.Telefone);

                if (command.ExecuteNonQuery() > 0)
                {
                    f.Id = (int)command.LastInsertedId;
                    return f;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Boolean Remover(int id)
        {
            try
            {

                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "DELETE FROM fornecedor WHERE id =@id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@id", id);

                return command.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Fornecedor BuscarPorId(int id)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "SELECT * FROM fornecedor WHERE id = @id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@id", id);

                var reader = command.ExecuteReader();
                Fornecedor f = null;
                while (reader.Read())
                {
                    f = new Fornecedor()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Nome = reader["nome_fornecedor"].ToString(),
                        NomeEmpresa = reader["nome_empresa"].ToString(),
                        Telefone = reader["telefone_fornecedor"].ToString()
                    };
                }

                reader.Close();

                return f;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Fornecedor> ListarMenu()
        {
            MySqlCommand command = Connection.Instance.CreateCommand();

            string sql = "SELECT * FROM fornecedor";
            command.CommandText = sql;
            var reader = command.ExecuteReader();
            List<Fornecedor> lFornecedor = new List<Fornecedor>();

            while (reader.Read())
            {
                Fornecedor forn = new Fornecedor()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nome = reader["nome_fornecedor"].ToString(),
                    NomeEmpresa = reader["nome_empresa"].ToString(),
                    Telefone = reader["telefone_fornecedor"].ToString()
                };

                lFornecedor.Add(forn);
            }

            reader.Close();
            return lFornecedor;

        }

        public DataTable ListarGrid()
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM fornecedor", Connection.Instance);
                sqlData.Fill(table);

                return table;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}