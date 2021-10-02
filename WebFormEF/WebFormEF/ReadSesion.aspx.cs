using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEF
{
    public partial class ReadSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbResult.Text = Session["welcome"].ToString;
        }
    }
}