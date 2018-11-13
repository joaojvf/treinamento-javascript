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
            if (!IsPostBack)
            {
                PopularGridProdutos();
                PopularGridItensVenda();
            }

        }
        protected void gdvItensVenda_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Remover"))
                {
                    int id = int.Parse((string)e.CommandArgument); // pega o ID o datakey name da linha clicada
                    Venda v = Session["venda"] as Venda;
                    Itens i = itemBs.BuscarPorId(id);
                    itemBs.Remover(i);
                    PopularGridItensVenda();
                }
                else if (e.CommandName.Equals("Editar"))
                {

                }

            }
            catch (Exception ee)
            {

            }
        }
        protected void gdvProdutos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int qtde = Convert.ToInt32(((TextBox)(gdvProdutos.Rows[e.RowIndex].FindControl("txtQuantidadeProduto"))).Text);
            double val = Convert.ToDouble(((Label)(gdvProdutos.Rows[e.RowIndex].FindControl("lblValorProduto"))).Text);

            Itens i = new Itens()
            {
                Quantidade = qtde,
                Valor = val
            };

            Venda v = Session["venda"] as Venda;
            int produto_id = (int)gdvProdutos.DataKeys[e.RowIndex].Value;

            itemBs.Inserir(i, produto_id, v);

            PopularGridItensVenda();

        }

        public void PopularGridItensVenda()
        {
            Venda v = Session["venda"] as Venda;
            DataTable dTable = itemBs.ListarGridItensVenda(v.Id);

            gdvItensVenda.DataSource = dTable;
            gdvItensVenda.DataBind();
        }

        public void PopularGridProdutos()
        {
            DataTable dTable = prodBs.ListarGrid();
            gdvProdutos.DataSource = dTable;
            gdvProdutos.DataBind();
        }


        
    }
}