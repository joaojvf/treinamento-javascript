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

        public double BuscarValorTotal (Venda v)
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

        public DataTable ListarGridPorCliente()
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM venda INNER JOIN cliente " +
                    "ON cliente.id = venda.cliente_id", Connection.Instance);
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