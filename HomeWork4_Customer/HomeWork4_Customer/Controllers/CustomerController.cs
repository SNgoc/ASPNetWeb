using HomeWork4_Customer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork4_Customer.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDBContext db;
        public CustomerController(CustomerDBContext db)//tạo hàm dựng để truyền data vào db
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            //show list cus
            var customer = await db.Customers.Select(c => new CustomerModel { Id = c.Id, Name = c.Name, Birthday = c.Birthday, Gender = c.Gender, Email = c.Email }).ToListAsync();
            return View(customer);//show  thông tin customer
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
        public async Task<IActionResult> Create(CustomerModel customer)//tạo hàm có parameter là đối tượng customer
        {
            Customer newCustomer = new Customer { Id = customer.Id, Name = customer.Name, Birthday = customer.Birthday, Gender = customer.Gender, Email = customer.Email };
            db.Customers.Add(newCustomer);
            await db.SaveChangesAsync();//lưu thay đổi vào db
            return RedirectToAction("Index"); //chuyền về trang Index khi create thành công
            //dùng các hàm có Async cuối => performance tăng
        }

        //Search filter
        public async Task<IActionResult> Search(string name)
        {
            if (string.IsNullOrEmpty(name))//fix lỗi null search ko nhập gì vào ô search ko hiển thị data
            {
                name = "";
            }
            var customers = await db.Customers.Where(ct => ct.Name.Contains(name)).Select(c => new CustomerModel { Id = c.Id, Name = c.Name, Birthday = c.Birthday, Gender = c.Gender, Email = c.Email }).ToListAsync();
            return View("Index", customers);
        }

        //delete
        public async Task<IActionResult> Delete(int id)
        {
            Customer cust = await db.Customers.SingleOrDefaultAsync(c => c.Id == id);
            if (cust != null)
            {
                //delete thành công
                db.Customers.Remove(cust);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
            ////ko tìm thấy
            //else
            //{
            //    //delete fail, hiển thị lại dữ liệu cũ
            //    Customer customer = await db.Customers.SingleOrDefaultAsync(c => c.Id == id);
            //    CustomerModel cm = new CustomerModel { Id = customer.Id, Name = customer.Name, Birthday = customer.Birthday, Gender = customer.Gender, Email = customer.Email };
            //    return View("UpdateorDelete", cm);
            //}
        }
    }
}
