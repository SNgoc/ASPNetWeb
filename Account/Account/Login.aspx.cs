using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Account
{
    public partial class Login : System.Web.UI.Page
    {
        string conStr = WebConfigurationManager.ConnectionStrings["T12008M0ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string u = txtUsername.Text;
            string p = txtPassword.Text;
            SqlConnection con = new SqlConnection(conStr);
            string query = "SELECT*FROM Account WHERE Username=@u AND Password=@p";
            SqlCommand com = new SqlCommand(query, con);
            // mở kết nối trk khi thi hành câu truy vấn
            con.Open();
            // truyền giá trị cho các tham số trong câu truy vấn 
            com.Parameters.Add(new SqlParameter("u", u));
            com.Parameters.Add(new SqlParameter("p", p));
            // thi hành câu truy vấn, kết quả nhận dc là đối tượng SqlDataReader
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblResult.Text = "Invalid Username or Password";
            }
            // đóng kết nồi
            con.Close();

        }
    }
}