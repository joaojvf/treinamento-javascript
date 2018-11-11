using Dao;
using Objects.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Business.Business
{
    public class ClienteBs
    {
        ClienteDAO cliente = new ClienteDAO();

        public DataTable Listar()
        {
            return cliente.ListarClientes();
        }

        public Cliente BuscarPorId(int id)
        {
            return cliente.BuscarPorId(id);
        }
        public Cliente Inserir(Cliente c)
        {
            return cliente.Inserir(c);
        }

        public Boolean Remover(int id)
        {
            return cliente.Remover(id);
        }

        public Cliente Editar(Cliente c)
        {
            return cliente.Editar(c);
        }
    }
}