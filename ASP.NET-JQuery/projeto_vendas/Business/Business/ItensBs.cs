using Dao;
using Objects.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Business.Business
{
    public class ItensBs
    {
        ItensDAO itens = new ItensDAO();

        public DataTable ListarGridItensVenda(int venda_id)
        {
            return itens.ListarGridItensVenda(venda_id);
        }

        public Itens Inserir(Itens i, int produto_id, int venda_id)
        {
            return itens.Inserir(i, produto_id, venda_id);
        }

        public bool Remover(int id)
        {
            return itens.Remover(id);
        }
    }
}