using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Neg;

namespace TP5_Benitez_Eric
{
    public partial class WebUi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Negocio m = new Negocio();
            DataUsuarios.DataSource = m.listar();
            DataUsuarios.DataBind();
        }
    }
}