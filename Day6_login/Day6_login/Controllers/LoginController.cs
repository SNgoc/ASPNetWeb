using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Day6_login.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        //check login
        public ActionResult CheckLogin(string username, string password, string remember)
        {
            //kiểm tra dăng nhập với username và password
            if (username == @"admin" && password == @"admin")
            {
                //kiểm tra xem remember có đc check hay không
                bool r = bool.Parse(remember);
                //kiểm tra đăng nhập và lưu vào header và cookie
                FormsAuthentication.SetAuthCookie(username, r);
                return RedirectToAction("Index", "Book");
            }
            //string notify = "Wrong username and password";
            return View("Index");
        }

        //check logout
        public ActionResult CheckLogout()
        {
            //thực hiện logout, xóa thông tin trong header
            FormsAuthentication.SignOut();
            return View("Index");
        }
    }
}