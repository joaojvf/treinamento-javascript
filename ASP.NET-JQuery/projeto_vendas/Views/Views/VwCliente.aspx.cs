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
            PopularGrid();
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
            PopularGrid();

        }

        protected void gdvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Remover"))
                {
                    int id = int.Parse((string)e.CommandArgument); // pega o ID o datakey name da linha clicada

                    cliBs.Remover(id);
                    PopularGrid();

                }

                if (e.CommandName.Equals("Abrir"))
                {
                    int id = int.Parse((string)e.CommandArgument);
                    Cliente cliente = cliBs.BuscarPorId(id);

                    Session["cliente"] = cliente;

                    Response.Redirect("~/Views/VwVendaPorCliente.aspx");
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