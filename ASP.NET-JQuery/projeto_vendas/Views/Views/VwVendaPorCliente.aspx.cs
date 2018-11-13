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
    public partial class VwVendaPorCliente : System.Web.UI.Page
    {
        VendaBs venBs = new VendaBs();


        protected void Page_Load(object sender, EventArgs e)
        {
            PopularGrid();


        }
        protected void gdvVendaCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Abrir"))
                {
                    int id = int.Parse((string)e.CommandArgument);
                    Venda venda = venBs.BuscarPorId(id);
                    Session["venda"] = venda;

                    Response.Redirect("~/Views/VwItensPorVenda.aspx");
                }
                if (e.CommandName.Equals("FinalizarVenda"))
                {
                    int id = int.Parse((string)e.CommandArgument);
                    Venda venda = new Venda();
                    venda = venBs.BuscarPorId(id);

                    venda.DataVenda = DateTime.Now;
                    venda = venBs.Editar(venda);
                    PopularGrid();
                }
            }
            catch (Exception ee)
            {

            }
        }

        protected void btnNovaVenda_Click(object sender, EventArgs e)
        {
            Cliente cliSession = Session["cliente"] as Cliente;

            Venda venda = new Venda()
            {
                TotalVenda = 0,
                Cliente = cliSession
            };

            venBs.Inserir(venda);
            PopularGrid();

        }

        public void PopularGrid()
        {
            DataTable dTable = venBs.ListarGridPorCliente(Session["cliente"] as Cliente);

            gdvVendaCliente.DataSource = dTable;
            gdvVendaCliente.DataBind();
        }
    }
}