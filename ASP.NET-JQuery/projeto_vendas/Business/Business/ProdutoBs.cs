using Dao;
using Dao.DAO;
using Objects.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Business.Business
{
    public class ProdutoBs
    {
        ProdutoDAO produto = new ProdutoDAO();


        public Produto Inserir(Produto p)
        {
            return produto.Inserir(p);
        }

        public Boolean Remover(int id)
        {
            return produto.Remover(id);
        }

        public DataTable ListarGrid()
        {
            return produto.ListarGrid();
        }
    }

   
}