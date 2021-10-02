using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEF
{
    public partial class ReadCookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //đọc cookie gửi lên từ trình duyệt
            HttpCookie cookie = Request.Cookies["Username"];
            //dọc9 dữ liệu từ cookie và hiện lên label
            lbResult.Text = cookie.Value;
        }
    }
}