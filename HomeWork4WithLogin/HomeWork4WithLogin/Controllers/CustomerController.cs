using HomeWork4WithLogin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork4WithLogin.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDBContext db;
        //upload Image
        IWebHostEnvironment env; //tự trỏ path đén thư mục wwwroot, lấy thông tin về biến môi trường server
        public CustomerController(CustomerDBContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;//dùng cho uploadImage
        }
        public IActionResult Index()
        {
            return View("Login");//trả về trang Login.cshtml mặc định khi chạy /Customer
        }

        public async Task<IActionResult> Login(AccountModel am)
        {
            if (ModelState.IsValid)//check lỗi login
            {
                Account acc = await db.Accounts.SingleOrDefaultAsync(c => c.Username == am.Username);//check username
                if (acc != null && acc.Password == am.Password)//nhập đủ username và password mới check, ko sẽ bị lỗi null
                {
                    return RedirectToAction("Show");
                }
                else//sai pass
                {
                    ViewBag.error = "Invalid username or password";
                }
            }
            return View();//báo lỗi sai pass
        }

        //show all list khi login success
        public async Task<IActionResult> Show()
        {
            //show all list cus with no image
            var customer = await db.Customers.Select(c => new CustomerModel { Id = c.Id, Name = c.Name, Birthday = c.Birthday, Gender = c.Gender, Email = c.Email }).ToListAsync();
            return View(customer);//show  thông tin customer
        }

        //show all in ShowAll.cshtml page
        public async Task<IActionResult> ShowAll()
        {
            //show all list cus with image
            var customer = await db.Customers.Select(c => new CustomerModel { Id = c.Id, Name = c.Name, Birthday = c.Birthday, Gender = c.Gender, Email = c.Email, Image = c.Image }).ToListAsync();
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
            if (ModelState.IsValid)//check validation trong required in CustomerModel.cs
            {
                //PHẦN ADD IMAGE
                //upload file
                string filename = customer.UploadImage.FileName;
                //var imagesPath = env.WebRootPath + "/images" + filename;//cách 1: tạo thư mục images bằng tay sau đó add vào

                //cách 2: tạo thư mục tự động
                var imagesFolder = Path.Combine(env.WebRootPath, "images");
                //check xem folder này đã có trên server (host) hay chưa, nếu chưa có thì tạo mới
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }


                var filePath = Path.Combine(imagesFolder, filename);
                var stream = new FileStream(filePath, FileMode.Create);
                await customer.UploadImage.CopyToAsync(stream);

                //PHẦN CREATE CUS
                Customer newCustomer = new Customer { Id = customer.Id, Name = customer.Name, Birthday = customer.Birthday, Gender = customer.Gender, Email = customer.Email, Image = filename };
                db.Customers.Add(newCustomer);
                await db.SaveChangesAsync();//lưu thay đổi vào db
                return RedirectToAction("Show"); //chuyền về trang Index khi create thành công
            }
            return View();
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
            return View("Show", customers);
        }

        //delete
        public async Task<IActionResult> Delete(int id)
        {
            Customer cust = await db.Customers.SingleOrDefaultAsync(c => c.Id == id);
            if (cust != null)//tìm thấy
            {
                //delete thành công
                db.Customers.Remove(cust);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Show");
        }

        //UpdateOrDelete page
        public async Task<IActionResult> UpdateOrDelete(int id)//get data cus from db
        {
            Customer customer = await db.Customers.SingleOrDefaultAsync(c => c.Id == id);
            CustomerModel cm = new CustomerModel { Id = customer.Id, Name = customer.Name, Birthday = customer.Birthday, Gender = customer.Gender, Email = customer.Email };
            return View(cm);
        }

        //update
        public async Task<IActionResult> Update(CustomerModel cust)
        {
            if (ModelState.IsValid)//check validation trong required in CustomerModel.cs
            {
                Customer oldCustomer = await db.Customers.SingleOrDefaultAsync(c => c.Id == cust.Id);
                if (oldCustomer != null) //tìm thấy
                {
                    oldCustomer.Name = cust.Name;
                    oldCustomer.Birthday = cust.Birthday;
                    oldCustomer.Gender = cust.Gender;
                    oldCustomer.Email = cust.Email;
                    await db.SaveChangesAsync(); // update data vào db
                    return RedirectToAction("Show");
                }
            }
            return RedirectToAction("UpdateorDelete"); //ko tìm thấy
        }

        //delete in viewdetails page
        public async Task<IActionResult> Delete2(int id)
        {
            Customer cust = await db.Customers.SingleOrDefaultAsync(c => c.Id == id);
            if (cust != null)
            {
                //delete thành công
                db.Customers.Remove(cust);
                await db.SaveChangesAsync();
                return RedirectToAction("Show");
            }
            //ko tìm thấy
            else
            {
                //delete fail, hiển thị lại dữ liệu cũ
                Customer customer = await db.Customers.SingleOrDefaultAsync(c => c.Id == id);
                CustomerModel cm = new CustomerModel { Id = customer.Id, Name = customer.Name, Birthday = customer.Birthday, Gender = customer.Gender, Email = customer.Email };
                return View("UpdateorDelete", cm);
            }
        }

        //tạo view cho remove cus page
        public async Task<IActionResult> RemoveCus()
        {
            var customers = await db.Customers.Select(c => new CustomerModel { Id = c.Id, Name = c.Name, Birthday = c.Birthday, Gender = c.Gender, Email = c.Email }).ToListAsync();//show list customer, kiểu dùng qua model trung gian CustomerModel.cs
            return View(customers);
        }

        //delete cus in remove page
        public async Task<IActionResult> DeleteCus(int id)
        {
            Customer cust = await db.Customers.SingleOrDefaultAsync(c => c.Id == id);
            if (cust != null)//tìm thấy
            {
                //delete thành công
                db.Customers.Remove(cust);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("RemoveCus");
        }

        //Edit page with Image
        public async Task<IActionResult> EditWithImage(int id)//get data cus from db
        {
            Customer customer = await db.Customers.SingleOrDefaultAsync(c => c.Id == id);
            CustomerModel cm = new CustomerModel { Id = customer.Id, Name = customer.Name, Birthday = customer.Birthday, Gender = customer.Gender, Email = customer.Email, Image = customer.Image };
            return View(cm);
        }

        //Edit with image
        public async Task<IActionResult> Edit(CustomerModel cust)
        {
            if (ModelState.IsValid)//check validation trong required in CustomerModel.cs
            {
                if (cust.UploadImage != null) //check nếu có up hình
                {
                    //PHẦN update IMAGE
                    //upload file
                    string filename = cust.UploadImage.FileName;
                    //var imagesPath = env.WebRootPath + "/images" + filename;//cách 1: tạo thư mục images bằng tay sau đó add vào

                    //cách 2: tạo thư mục tự động
                    var imagesFolder = Path.Combine(env.WebRootPath, "images");
                    //check xem folder này đã có trên server (host) hay chưa, nếu chưa có thì tạo mới
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }
                    var filePath = Path.Combine(imagesFolder, filename);
                    var stream = new FileStream(filePath, FileMode.Create);
                    await cust.UploadImage.CopyToAsync(stream);
                    cust.Image = filename;
                }
                else//ko có upload hình
                {
                    Customer oldCusImg = await db.Customers.SingleOrDefaultAsync(c => c.Id == cust.Id);
                    cust.Image = oldCusImg.Image;
                }

                Customer oldCustomer = await db.Customers.SingleOrDefaultAsync(c => c.Id == cust.Id);
                if (oldCustomer != null) //tìm thấy
                {
                    oldCustomer.Name = cust.Name;
                    oldCustomer.Birthday = cust.Birthday;
                    oldCustomer.Gender = cust.Gender;
                    oldCustomer.Email = cust.Email;
                    oldCustomer.Image = cust.Image;
                    await db.SaveChangesAsync(); // update data vào db
                    return RedirectToAction("Show");
                }
            }
            return RedirectToAction("Show"); //ko tìm thấy
        }
    }
}
