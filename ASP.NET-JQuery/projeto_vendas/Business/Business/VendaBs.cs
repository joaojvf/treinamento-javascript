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

        public DataTable ListarGridPorCliente()
        {
            return venda.ListarGridPorCliente();
        }
    }
}