using Dao;
using Objects.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Business.Business
{
    public class FornecedorBs
    {
        FornecedorDAO fornecedor = new FornecedorDAO();

        public Fornecedor Inserir(Fornecedor f)
        {
            return fornecedor.Inserir(f);
        }

        public Boolean Remover (int id)
        {
            return  fornecedor.Remover(id);
        }

        public List<Fornecedor> ListarMenu()
        {
            return fornecedor.ListarMenu();
        }

        public Fornecedor BuscarPorId(int id)
        {
            return fornecedor.BuscarPorId(id);
        }

        public DataTable ListarGrid()
        {
            return fornecedor.ListarGrid();
        }
    }
}