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
    public class VendaDAO
    {
        public Venda Inserir(Venda v)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "INSERT INTO venda (cliente_id, total_venda) VALUES (@cliente_id, @total_venda)";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@cliente_id", v.Cliente.Id);
                command.Parameters.AddWithValue("@total_venda", v.TotalVenda);


                if (command.ExecuteNonQuery() > 0)
                {
                    v.Id = (int)command.LastInsertedId;
                    return v;
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

        public double BuscarValorTotal(Venda v)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "SELECT SUM(valor) FROM venda AS v INNER JOIN  itens AS i ON v.id = i.venda_id " +
                    "WHERE v.id = @id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@id", v.Id);
                var reader = command.ExecuteReader();
                double novoTotal = -1;
                while (reader.Read())
                {
                    novoTotal = double.Parse(reader["valor"].ToString());
                }

                reader.Close();

                return novoTotal;

            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public DataTable ListarGridPorCliente(Cliente c)
        {
            try
            {
                DataTable table = new DataTable();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM venda, cliente " +
                    "WHERE @id = cliente.id AND cliente.id = venda.cliente_id", Connection.Instance);
                cmd.Parameters.AddWithValue("@id", c.Id);
                MySqlDataAdapter sqlData = new MySqlDataAdapter(cmd);

                sqlData.Fill(table);

                return table;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public Venda Editar(Venda v)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "UPDATE venda SET data_venda = @data, total_venda = @total WHERE id = @id";

                command.CommandText = sql;
                command.Parameters.AddWithValue("@data", v.DataVenda);
                command.Parameters.AddWithValue("@total", v.TotalVenda);
                command.Parameters.AddWithValue("@id", v.Id);
                
                return command.ExecuteNonQuery() > 0 ? v : null;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Venda BuscarPorId(int id)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "SELECT * FROM venda WHERE id = @id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@id", id);

                var reader = command.ExecuteReader();
                Venda v = null;
                while (reader.Read())
                {
                    v = new Venda()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        
                        TotalVenda = double.Parse(reader["total_venda"].ToString()),
                    };
                }
                int cliente_id = -1;
                cliente_id = int.Parse(reader["cliente_id"].ToString());
                v.Cliente = new ClienteDAO().BuscarPorId(cliente_id);

                reader.Close();

                return v;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}