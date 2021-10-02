using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormEF
{
    public partial class Create : System.Web.UI.Page
    {
        T12008M0Entities db = new T12008M0Entities();//tạo kết nối
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //đọc thông tin từ các ô nhập liệu
            string username = textUsername.Text;
            string password = textPassword.Text;
            string fullname = textFullname.Text;
            string sBrithday = textBirthday.Text;
            DateTime birthday = DateTime.ParseExact(sBrithday, "yyyy-MM-dd", null);
            string sGender = ddlGender.SelectedValue;
            bool gender = sGender == "1";
            Account acc = new Account { Username = username, Password = password, Fullname = fullname, Birthday = birthday, Gender = gender };
            //thêm đối tượng acc vào entities list
            db.Accounts.Add(acc);
            db.SaveChanges(); //lưu thay đổi vào db
            Response.Redirect("Default.aspx");//chuyển trang
        }
    }
}