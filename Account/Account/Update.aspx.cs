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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string conStr = WebConfigurationManager.ConnectionStrings["T12008M0ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //đọc giá trị truyền qua từ QueryString
                string id = Request.Params["id"];
                SqlConnection con = new SqlConnection(conStr);
                string query = $"SELECT Id,Username,Password,Fullname,Birthday,Gender FROM Account WHERE Id = '{id}'";
                SqlCommand com = new SqlCommand(query, con);
                // mở kết nối trk khi thi hành câu truy vấn
                con.Open();
                // truyền giá trị cho các tham số trong câu truy vấn
                //cách 2
                //com.Parameters.Add(new SqlParameter("id", Convert.ToInt32(id)));
                // thi hành câu truy vấn, kết quả nhận dc là đối tượng SqlDataReader
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    txtUsername.Text = reader["Username"].ToString();
                    txtFullname.Text = reader["Fullname"].ToString();
                    txtBirthDay.Text = Convert.ToDateTime(reader["Birthday"]).ToString("yyyy-MM-dd");
                    ddlGender.SelectedValue = ((bool)reader["Gender"]) ? "1" :"0";
                }
                // đóng kết nồi
                con.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //đọc giá trị truyền qua từ QueryString
            string id = Request.Params["id"];
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string fullname = txtFullname.Text;
            string birthday = Convert.ToDateTime(txtBirthDay.Text).ToString("yyyy-MM-dd");
            string gender = ddlGender.SelectedValue;
            //xử lý gender
            bool bgender = Convert.ToInt32(gender) == 1;

            SqlConnection con = new SqlConnection(conStr);
            string query = $"UPDATE Account SET Username='{username}', Password='{password}', Fullname='{fullname}', Birthday='{birthday}', Gender='{bgender}' WHERE Id='{id}'";
            SqlCommand com = new SqlCommand(query, con);
            // mở kết nối trk khi thi hành câu truy vấn
            con.Open();
            // truyền giá trị cho các tham số trong câu truy vấn 
            com.Parameters.Add(new SqlParameter("u", username));
            com.Parameters.Add(new SqlParameter("p", password));
            com.Parameters.Add(new SqlParameter("fullname", fullname));
            //xử lý birthday (cách 2)
            //DateTime bday = DateTime.ParseExact(birthday, "yyyy-MM-dd", null);
            //SqlParameter birthdayParam = new SqlParameter("birthday", bday);
            //birthdayParam.SqlDbType = System.Data.SqlDbType.DateTime;
            //com.Parameters.Add(birthdayParam);
            //xử lý gender (cách 2)
            //bool bgender = Convert.ToInt32(gender) == 1;
            //com.Parameters.Add(new SqlParameter("gender", bgender));
            // thi hành câu truy vấn, kết quả nhận dc là đối tượng SqlDataReader
            int result = com.ExecuteNonQuery();
            if (result > 0)
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
    //code update
    //string query = "UPDATE Account SET Username=@u, Password=@p, Fullname=@fullname, Birthday=@birthday, Gender=@gender WHERE Id=@id";
}