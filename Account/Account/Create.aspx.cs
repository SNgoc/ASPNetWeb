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
    public partial class Create : System.Web.UI.Page
    {
        string conStr = WebConfigurationManager.ConnectionStrings["T12008M0ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string fullname = txtFullname.Text;
            string birthday = txtBirthDay.Text;
            string gender = ddlGender.SelectedValue;

            SqlConnection con = new SqlConnection(conStr);
            string query = "INSERT INTO Account(Username,Password,Fullname,Birthday,Gender)VALUES(@u,@p,@fullname,@birthday,@gender)";
            SqlCommand com = new SqlCommand(query, con);
            // mở kết nối trk khi thi hành câu truy vấn
            con.Open();
            // truyền giá trị cho các tham số trong câu truy vấn 
            com.Parameters.Add(new SqlParameter("u", username));
            com.Parameters.Add(new SqlParameter("p", password));
            com.Parameters.Add(new SqlParameter("fullname", fullname));
            //xử lý birthday
            DateTime bday = DateTime.ParseExact(birthday, "yyyy-MM-dd",null);
            SqlParameter birthdayParam = new SqlParameter("birthday",bday);
            birthdayParam.SqlDbType = System.Data.SqlDbType.DateTime;
            com.Parameters.Add(birthdayParam);
            //xử lý gender
            bool bgender = Convert.ToInt32(gender) == 1;
            com.Parameters.Add(new SqlParameter("gender", bgender));
            // thi hành câu truy vấn, kết quả nhận dc là đối tượng SqlDataReader
            int result = com.ExecuteNonQuery();
            if (result>0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblResult.Text = "Error appear. Pls try again";
            }
            // đóng kết nồi
            con.Close();
        }
    }
}