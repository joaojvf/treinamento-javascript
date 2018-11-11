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
    public partial class VwFornecedor : System.Web.UI.Page
    {
        FornecedorBs forBs = new FornecedorBs();

        protected void Page_Load(object sender, EventArgs e)
        {
            PopularGrid();
        }

        protected void btnCadastrarFornecedor_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor()
            {
                Nome = txtNome.Text,
                NomeEmpresa = txtEmpresa.Text,
                Telefone = txtTelefone.Text,
            };

            forBs.Inserir(fornecedor);

            PopularGrid();

        }

        protected void gdvFornecedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Remover"))
                {
                    int id = int.Parse((string)e.CommandArgument); // pega o ID o datakey name da linha clicada

                    forBs.Remover(id);
                    PopularGrid();

                }
            }
            catch (Exception ee)
            {

            }
        }

        public void PopularGrid()
        {
            DataTable dTable = forBs.ListarGrid();

            gdvFornecedor.DataSource = dTable;
            gdvFornecedor.DataBind();
        }
    }
}
