using DemoBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBank.Controllers
{
    public class PeopleController : Controller
    {
        BankDBContext db;
        public PeopleController(BankDBContext db)
        {
            this.db = db;
        }
        public IActionResult Index()//đây là trang login
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            TbPerson p = await db.TbPeople.SingleOrDefaultAsync(pp => pp.Username == username);//check login
            if (p != null)
            {
                if (p.Password == password)
                {
                    //SESSION
                    HttpContext.Session.SetString("username", username);
                    //do Roles có kiểu int? (nullable) => cần dùng p.Roles.Value để lấy giá trị
                    if (p.Roles.Value)
                    {
                        //là employee
                        //sử dụng session thì ko cần viewbag
                        //ViewBag.username = username;
                        return View("Employee", p);
                    }
                    else//là customer
                    {
                        return View("Customer", p);//đưa vào model p, customer là tên view trong people
                    }
                }
            }
            //sai tài khoản hoặc pass
            return RedirectToAction("InvalidLogin");
        }

        public IActionResult InvalidLogin()
        {
            return View();
        }

        //show all list customer from db
        public async Task<IActionResult> Show() //show all customer mà ko hiển thị employee
        {
            //là employee
            //ViewBag.username = username; session ko cần
            var customer = await db.TbPeople.Where(c => !c.Roles.Value).ToListAsync();// phủ định của true là customer
            return View(customer);
        }

        //remove a customer from db
        public async Task<IActionResult> Remove() //
        {
            //ViewBag.username = username; session ko cần
            var customer = await db.TbPeople.Where(c => !c.Roles.Value).ToListAsync();// phủ định của true là customer
            return View(customer);
        }

        public async Task<IActionResult> Delete(string username)//
        {
            var cus = await db.TbPeople.SingleOrDefaultAsync(p => p.Username == username);
            db.TbPeople.Remove(cus);
            await db.SaveChangesAsync();//lưu thay đổi vào db
            return RedirectToAction("Remove");
        }
    }
}
