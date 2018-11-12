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
        public Itens Inserir(Itens i, int produto_id, int venda_id)
        {
            try
            {
                i.Venda = new VendaDAO().BuscarPorId(venda_id);
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

        public bool Remover(int id)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "DELETE FROM itens WHERE id =@id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@id", id);

                return command.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable ListarGridItensVenda(int venda_id)
        {
            try
            {
                Venda v = new VendaDAO().BuscarPorId(venda_id);
                DataTable table = new DataTable();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM venda, itens " +
                    "WHERE @id = venda.id AND venda.id = itens.venda_id", Connection.Instance);
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