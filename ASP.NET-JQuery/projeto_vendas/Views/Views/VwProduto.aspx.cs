using Business.Business;
using Objects.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views
{
    public partial class VwProduto : System.Web.UI.Page
    {
        ProdutoBs prodBs = new ProdutoBs();
        FornecedorBs fornBs = new FornecedorBs();

        protected void Page_Load(object sender, EventArgs e)
        {
            PopularGrid();
            PopularMenuDD();
        }

        protected void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = fornBs.BuscarPorId(int.Parse(ddlFornecedor.SelectedValue));

            Produto produto = new Produto()
            {
                Nome = txtNome.Text,
                Valor = double.Parse(txtValor.Text),
                Fornecedor = fornecedor
            };

            prodBs.Inserir(produto);

            PopularGrid();

        }

        protected void gdvProduto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Remover"))
                {
                    int id = int.Parse((string)e.CommandArgument); // pega o ID o datakey name da linha clicada

                    prodBs.Remover(id);
                    PopularGrid();

                }
            }
            catch (Exception ee)
            {

            }
        }

        public void PopularGrid()
        {
            DataTable dTable = prodBs.ListarGridProdutoFornecedor();

            gdvProduto.DataSource = dTable;
            gdvProduto.DataBind();
        }

        private void PopularMenuDD()
        {
            List<Fornecedor> lFornecedor = fornBs.ListarMenu();

            ddlFornecedor.DataSource = lFornecedor;
            ddlFornecedor.DataTextField = "Nome";
            ddlFornecedor.DataValueField = "Id";
            ddlFornecedor.DataBind();

        }
    }
}