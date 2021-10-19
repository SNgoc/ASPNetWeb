using DemoAuthorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAuthorization.Controllers
{
    public class DemoController : Controller
    {
        DemoLoginContext db;
        public DemoController(DemoLoginContext db)
        {
            this.db = db;
        }

        private Role FindRoleById(int id)
        {
            return db.Roles.SingleOrDefault(r => r.Id == id);
        }

        //[AllowAnonymous]  // cho phép tất cả m.n có thể truy cập
        [Authorize(Roles ="Admin, User")] //chỉ cho phép Admin, user vào trang index để view, account demo ko đc
        public IActionResult Index()
        {
            //sử dụng eager loading cho roles
            //eager loding cũng giúp giải quyết bài toán N+1 query khi truy cập dữ liệu của 1 bảng + relationship của bảng này
            var accounts = db.Accounts.Include(a => a.AccountRoles).ThenInclude(ar => ar.Role);

            return View(accounts);
        }

        [Authorize(Roles = "Admin")]//chỉ cho phép Admin vào trang create new
        public IActionResult Create()
        {
            return View();
        }
    }
}
