using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views.Views
{
    public partial class PaginaMestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ConsultarProdutos(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/VwProduto.aspx");
        }
        protected void ConsultarFornecedores(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/VwFornecedor.aspx");
        }
    }
}