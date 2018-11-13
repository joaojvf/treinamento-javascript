using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Data;
using Dao.DAO;
using Objects.Objetos;
using MySql.Data.MySqlClient;

namespace Dao
{
    public class ItensDAO
    {
        public Itens Inserir(Itens i, int produto_id, Venda v)
        {
            try
            {
                i.Valor = i.Valor * i.Quantidade;
                i.Venda = v;
                i.Venda.TotalVenda += i.Valor;
                i.Produto = new ProdutoDAO().BuscarPorId(produto_id);

                MySqlCommand command = Connection.Instance.CreateCommand();
                string sql = "INSERT INTO itens (quantidade, valor, venda_id, produto_id) " +
                    "VALUES (@quantidade, @valor, @venda_id, @produto_id)";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@produto_id", i.Produto.Id);
                command.Parameters.AddWithValue("@quantidade", i.Quantidade);
                command.Parameters.AddWithValue("@valor", i.Valor);
                command.Parameters.AddWithValue("@venda_id", i.Venda.Id);

                if (command.ExecuteNonQuery() > 0)
                {
                    i.Id = (int)command.LastInsertedId;
                    i.Venda = new VendaDAO().AtualizaSaldo(i.Venda);

                    return i;
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

        public bool Remover(Itens i)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "DELETE FROM itens WHERE id =@id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@id", i.Id);

                if (command.ExecuteNonQuery() > 0)
                {
                    i.Venda.TotalVenda -= i.Valor;
                    i.Venda = new VendaDAO().AtualizaSaldo(i.Venda);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Itens BuscarPorId(int id)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "SELECT * FROM itens WHERE id = @id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@id", id);

                var reader = command.ExecuteReader();
                Itens i = null;
                while (reader.Read())
                {
                    i = new Itens()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Quantidade = int.Parse(reader["quantidade"].ToString()),
                        Valor = double.Parse(reader["valor"].ToString())
                    };
                }

                int venda_id = int.Parse(reader["venda_id"].ToString());
                int produto_id = int.Parse(reader["produto_id"].ToString());
                reader.Close();

                i.Venda = new VendaDAO().BuscarPorId(venda_id);
                i.Produto = new ProdutoDAO().BuscarPorId(produto_id);

                return i;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DataTable ListarGridItensVenda(int venda_id)
        {
            try
            {
                Venda v = new VendaDAO().BuscarPorId(venda_id);
                DataTable table = new DataTable();

                MySqlCommand cmd = new MySqlCommand("SELECT itens.id, nome_produto, quantidade, valor FROM venda, itens, produto " +
                    "WHERE @id = venda.id AND venda.id = itens.venda_id AND itens.produto_id = produto.id", Connection.Instance);
                cmd.Parameters.AddWithValue("@id", v.Id);
                MySqlDataAdapter sqlData = new MySqlDataAdapter(cmd);

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