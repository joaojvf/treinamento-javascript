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
                    //Session["cliente"] = venBs.BuscarPorId(int.Parse((string)e.CommandArgument));
                    Response.Redirect("");
                }
                if (e.CommandName.Equals("FinalizarVenda"))
                {
                    // adiciona data atual para a venda clicada
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
            DataTable dTable = venBs.ListarGridPorCliente();

            gdvVendaCliente.DataSource = dTable;
            gdvVendaCliente.DataBind();
        }
    }
}