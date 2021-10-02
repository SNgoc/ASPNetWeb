using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace D1Hello
{
    public partial class HelloWorld : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)// trường hợp trang web load lại
            {
                //chkRemember.Checked = false;
            }
            else
            {
                //chkRemember.Checked = true;
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            lbDisplay.Text = "The New World";//khi chạy lên sẽ đổi text hiển thị trong label là Hello World thành text này
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string u = TextUser.Text;
            string p = TextPassword.Text;
            if (u == @"Aptech" && p == @"123")
            {
                //chuyển trang trong trường hợp đăng nhập đúng
                Response.Redirect("HelloWorld.aspx");
                lbResult.Text = "Login success";
            }
            else
            {
                lbResult.Text = "Invalid";
            }
        }
    }
}