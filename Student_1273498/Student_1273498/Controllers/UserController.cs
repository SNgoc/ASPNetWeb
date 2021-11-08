using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_1273498.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_1273498.Controllers
{
    public class UserController : Controller
    {
        UsersDBContext db;
        public UserController(UsersDBContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View("Login");
        }

        public async Task<IActionResult> Login(UserModel um)
        {
            if (ModelState.IsValid)//check lỗi login
            {
                TbUser u = await db.TbUsers.SingleOrDefaultAsync(c => c.Username == um.Username);//check username
                if (u != null && u.Password == um.Password)//nhập đủ username và password mới check, ko sẽ bị lỗi null
                {
                    if (u.IsAdmin == true)
                    {
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        return RedirectToAction("Show");
                    }
                }
                else//sai pass
                {
                    ViewBag.error = "Invalid username or password";
                }
            }
            return View();//báo lỗi sai pass
        }

        public async Task<IActionResult> Show()//get data cus from db
        {
            var user = await db.TbUsers.Where(c => !c.IsAdmin.Value).ToListAsync();// phủ định của true là customer
            return View(user);
        }

        //Create a News
        //lưu ý, cần có 2 phương thức giống tên nhau:
        //1 hiển thị trang create hiện tại để nhập dữ liệu input
        //1 dùng để Create a news
        public IActionResult Create()
        {
            return View();//trả về trang hiện tại để nhập dữ liệu input
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel um)//tạo hàm có parameter là đối tượng customer
        {
            if (ModelState.IsValid)//check validation trong required in CustomerModel.cs
            {
                if (um.IsAdmin == null)
                {
                    um.IsAdmin = false;
                }
                //PHẦN CREATE CUS
                TbUser newUser = new TbUser { UserId = um.UserId, Fullname = um.Fullname, Username = um.Username, Password = um.Password, Address = um.Address, Email = um.Email, IsAdmin = um.IsAdmin };
                db.TbUsers.Add(newUser);
                await db.SaveChangesAsync();//lưu thay đổi vào db
                return RedirectToAction("Create"); //chuyền về trang Index khi create thành công
            }
            return View();
            //dùng các hàm có Async cuối => performance tăng
        }
    }
}
