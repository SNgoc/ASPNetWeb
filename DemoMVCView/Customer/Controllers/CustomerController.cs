using Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer.Controllers
{
    public class CustomerController : Controller
    {
        T12008M0Entities db = new T12008M0Entities();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] //method post
        public ActionResult Create(Customer.Models.Customer cust)// dùng kiểu này khi name table trong db trùng tên với name project
        {
            //check validation của dữ liệu nhập
            if (ModelState.IsValid)
            {
                db.Customers.Add(cust);//thêm obj cust vào danh sách
                db.SaveChanges(); //lưu các thay đổi vào db => tạo record mới trong db
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}