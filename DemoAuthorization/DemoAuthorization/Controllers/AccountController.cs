using DemoAuthorization.Models;
using DemoAuthorization.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAuthorization.Controllers
{
    public class AccountController : Controller
    {
        DemoLoginContext db;
        SecurityManager securityManager = new SecurityManager();

        public AccountController(DemoLoginContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var account = ProcessLogin(username, password);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || account == null)//bắt lỗi null hoặc để trống
            {
                ViewBag.error = "Invalid username or password";
                return View("Index");
            }
            else
            {
                await securityManager.SignIn(this.HttpContext, account);
                return RedirectToAction("Welcome");
            }
        }

        [NonAction]
        private Account ProcessLogin(string username, string password)
        {
            //query account từ db, có check trạng thái enable
            var account = db.Accounts.SingleOrDefault(a => a.Username == username && a.Enable == true);//check account login
            if (account != null)
            {
                //check password
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }
            return null;
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await securityManager.SignOut(this.HttpContext);
            return RedirectToAction("Index");
        }
    }
}
