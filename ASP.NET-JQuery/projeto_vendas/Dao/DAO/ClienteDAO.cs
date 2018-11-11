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
    public class ClienteDAO
    {

        public DataTable ListarClientes()
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("SELECT * FROM cliente", Connection.Instance);
                sqlData.Fill(table);

                return table;
            }
            catch (Exception e)
            {
                return null;
            }

        }


        public Cliente Inserir(Cliente c)
        {
            try
            {

                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "INSERT INTO cliente(nome_cliente,cpf_cliente, telefone_cliente, email_cliente)" +
                    " VALUES (@nome,@cpf,@telefone, @email)";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@nome", c.Nome);
                command.Parameters.AddWithValue("@cpf", c.Cpf);
                command.Parameters.AddWithValue("@telefone", c.Telefone);
                command.Parameters.AddWithValue("@email", c.Email);

                if (command.ExecuteNonQuery() > 0)
                {
                    c.Id = (int)command.LastInsertedId;
                    return c;
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

                string sql = "DELETE FROM cliente WHERE id =@id";
                command.CommandText = sql;
                command.Parameters.AddWithValue("@id", id);

                return command.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Cliente Editar(Cliente c)
        {
            try
            {
                MySqlCommand command = Connection.Instance.CreateCommand();

                string sql = "UPDATE cliente SET nome_cliente = @nome, cpf_cliente = @cpf, " +
                    "telefone_cliente = @telefone, email_cliente = @email WHERE id = @id";

                command.CommandText = sql;
                command.Parameters.AddWithValue("@nome", c.Nome);
                command.Parameters.AddWithValue("@cpf", c.Cpf);
                command.Parameters.AddWithValue("@telefone", c.Telefone);
                command.Parameters.AddWithValue("@email", c.Email);


                return command.ExecuteNonQuery() > 0 ? c : null;

            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}