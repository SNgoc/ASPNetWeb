using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEF
{
    public partial class WriteCookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //tạo cookie
            HttpCookie cookie = new HttpCookie("Username", "Nero");
            //gửi cookie vào respone header nhờ trình duyệt lưu lại
            Response.Cookies.Add(cookie); //add cookie vào chrome
        }
    }
}