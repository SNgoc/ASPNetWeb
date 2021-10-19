using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewCustomer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewCustomer.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDBContext db;
        public CustomerController(CustomerDBContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            //show list cus
            var customer = await db.Customers.Select(c => new CustomerModel { Id = c.Id, Name = c.Name, Birthday = c.Birthday, Gender = c.Gender.Value ? 1 : 0, Email = c.Email }).ToListAsync();
            return View(customer);
        }

        public async Task<IActionResult> UpdateorDelete(int id)//get data cus from db
        {
            Customer customer = await db.Customers.SingleOrDefaultAsync(c => c.Id == id);
            CustomerModel cm = new CustomerModel { Id = customer.Id, Name = customer.Name, Birthday = customer.Birthday, Gender = customer.Gender.Value ? 1 : 0, Email = customer.Email };
            return View(cm);
        }

        //update
        public async Task<IActionResult> Update(CustomerModel cust)
        {
            Customer oldCustomer = await db.Customers.SingleOrDefaultAsync(c => c.Id == cust.Id);
            if (oldCustomer != null) //tìm thấy
            {
                oldCustomer.Name = cust.Name;
                oldCustomer.Birthday = cust.Birthday;
                oldCustomer.Gender = cust.Gender == 1 ? true : false;//nếu cust.Gender == 1 là true, 0 là false
                oldCustomer.Email = cust.Email;
                await db.SaveChangesAsync(); // update data vào db
                return RedirectToAction("Index");
            }
            return RedirectToAction("UpdateorDelete"); //ko tìm thấy
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
               return RedirectToAction("Index");
            }
            //ko tìm thấy
            else
            {
                //delete fail, hiển thị lại dữ liệu cũ
                Customer customer = await db.Customers.SingleOrDefaultAsync(c => c.Id == id);
                CustomerModel cm = new CustomerModel { Id = customer.Id, Name = customer.Name, Birthday = customer.Birthday, Gender = customer.Gender.Value ? 1 : 0, Email = customer.Email };
                return View("UpdateorDelete", cm);
            }
        }

        //Search filter
        public async Task<IActionResult> Search(string name)
        {
            if (string.IsNullOrEmpty(name))//fix lỗi null search ko nhập gì vào ô search ko hiển thị data
            {
                name = "";
            }
            var customers = await db.Customers.Where(ct => ct.Name.Contains(name)).Select(c => new CustomerModel { Id = c.Id, Name = c.Name, Birthday = c.Birthday, Gender = c.Gender.Value ? 1 : 0, Email = c.Email }).ToListAsync();
            return View("Index", customers);
        }

        //Create a News
        //lưu ý, cần có 2 phương thức giống tên nhau:
        //1 hiển thị trang create hiện tại để nhập dữ liệu input
        //1 dùng để Create a news
        public IActionResult Create()
        {
            return View();//trả về trang hiện tại để nhập dữ liệu input, phải có view để hiển thị trang
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerModel customer)//tạo hàm có parameter là đối tượng customer
        {
            Customer newCustomer = new Customer { Id = customer.Id, Name = customer.Name, Birthday = customer.Birthday, Gender = customer.Gender.Value == 1 ? true : false, Email = customer.Email };
            db.Customers.Add(newCustomer);
            await db.SaveChangesAsync();//lưu thay đổi vào db
            return RedirectToAction("Index"); //chuyền về trang Index khi create thành công
            //dùng các hàm có Async cuối => performance tăng
        }
    }
}
