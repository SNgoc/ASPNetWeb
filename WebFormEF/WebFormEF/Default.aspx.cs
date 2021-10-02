using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEF
{
    public partial class Default : System.Web.UI.Page
    {
        T12008M0Entities db = new T12008M0Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = db.Accounts.ToList();
            GridView1.DataBind();
        }
    }
}