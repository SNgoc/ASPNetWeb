using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAuthen.Controllers
{
    //route là đặt tên phương thức là nơi mà đường dẫn trên thanh địa chỉ muốn truy cập vào
    [Route("login")]

    public class LoginController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("process")]
        public IActionResult Process(string username, string password)
        {
            if(@"aptech"==username && @"123" == password)
            {
                HttpContext.Session.SetString("username", username);
                return View("Welcome");
            }
            else
            {
                ViewBag.error = "Invalid Username or Password";
                return View("Index");
            }
        }

        [Route("abc")]
        public int Testabc()
        {
            return 10;
        }
    }
}
