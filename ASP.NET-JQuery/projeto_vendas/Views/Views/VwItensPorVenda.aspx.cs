using Business.Business;
using Objects.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views.Views
{
    public partial class VwItensPorVenda : System.Web.UI.Page
    {
        ItensBs itemBs = new ItensBs();
        VendaBs vendaBs = new VendaBs();
        ProdutoBs prodBs = new ProdutoBs();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gdvProdutos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string strQtde = (gdvProdutos.Rows[e.RowIndex].FindControl("txtQuantidadeProduto") as TextBox).Text;
            int qtde;


            if (Int32.TryParse(strQtde, out qtde))
            {
                Itens i = new Itens()
                {
                    Quantidade = qtde,
                };

                Venda v = Session["venda"] as Venda;
                int produto_id = e.RowIndex;

                itemBs.Inserir(i, produto_id, v.Id);

                //PopularGrid();
            }
        }

        //public void PopularGrid()
        //{
        //    Venda v = Session["venda"] as Venda;
        //    DataTable dTable = itemBs.ListarGridItensVenda(v.Id);

        //    gdvProdutos.DataSource = dTable;
        //    gdvProdutos.DataBind();
        //}



    }
}