using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEF
{
    public partial class WriteSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["welcome"] = "Welcome to T12008M0 class";
            //hoặc cách 2
            //Session.Add("welcome", "Welcome to T12008M0 class");
        }
    }
}