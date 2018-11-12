using Dao;
using Objects.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Business.Business
{
    public class VendaBs
    {
        VendaDAO venda = new VendaDAO();

        public Venda Inserir(Venda v)
        {
            return venda.Inserir(v);
        }

        public DataTable ListarGridPorCliente(Cliente c)
        {
            return venda.ListarGridPorCliente(c);
        }

        public Venda BuscarPorId(int id)
        {
            return venda.BuscarPorId(id);
        }

        public Venda Editar(Venda v)
        {
            return venda.Editar(v);
        }
    }
}