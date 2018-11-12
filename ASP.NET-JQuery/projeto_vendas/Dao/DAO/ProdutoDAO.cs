using MySql.Data.MySqlClient;
using Objects.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Dao.DAO
{
    public class ProdutoDAO
    {
        public Produto Inserir(Produto p)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "INSERT INTO produto(nome_produto, valor_produto, id_fornecedor)" +
                    " VALUES (@nome,@valor,@id_fornecedor)";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@nome", p.Nome);
                command.Parameters.AddWithValue("@valor", p.Valor);
                command.Parameters.AddWithValue("@id_fornecedor", p.Fornecedor.Id);

                if (command.ExecuteNonQuery() > 0)
                {
                    p.Id = (int)command.LastInsertedId;
                    return p;
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

                string sql = "DELETE FROM produto WHERE id =@id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@id", id);

                return command.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable ListarGrid()
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM produto LEFT JOIN fornecedor" +
                    " ON produto.id_fornecedor = fornecedor.id", Connection.Instance);
                sqlData.Fill(table);

                return table;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public Produto BuscarPorId(int id)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "SELECT * FROM produto WHERE id = @id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@id", id);

                var reader = command.ExecuteReader();
                Produto p = null;
                while (reader.Read())
                {
                    p = new Produto()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Nome = reader["nome_produto"].ToString(),
                        Valor = double.Parse(reader["valor_produto"].ToString()),
                        
                    };
                }

                int id_fornecedor = int.Parse(reader["id_fornecedor"].ToString());
                reader.Close();

                p.Fornecedor = new FornecedorDAO().BuscarPorId(id_fornecedor);

                return p;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}