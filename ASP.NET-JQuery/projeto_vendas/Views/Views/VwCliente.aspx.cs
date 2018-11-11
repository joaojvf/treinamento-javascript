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
    public partial class VwCliente : System.Web.UI.Page
    {
        ClienteBs cliBs = new ClienteBs();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                Nome = txtNome.Text,
                Cpf = txtCpf.Text,
                Telefone = txtTelefone.Text,
                Email =  txtEmail.Text
            };

            cliBs.Inserir(cliente);

        }

        protected void gdvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Remover"))
                {
                    int rowIndex = int.Parse((string)e.CommandArgument); // pega o ID o datakey name da linha clicada
                    int id = Convert.ToInt32(gdvCliente.DataKeys[rowIndex].Value);

                    cliBs.Remover(id);
                    PopularGrid();

                }
            }
            catch (Exception ee)
            {

            }
        }

        public void PopularGrid()
        {
            DataTable dTable = cliBs.Listar();

            gdvCliente.DataSource = dTable;
            gdvCliente.DataBind();
        }
    }
}