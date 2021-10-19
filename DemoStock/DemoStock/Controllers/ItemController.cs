using DemoStock.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoStock.Controllers
{
    public class ItemController : Controller
    {
        StockDBContext db;
        //upload Image
        IWebHostEnvironment env; //tự trỏ path đén thư mục wwwroot, lấy thông tin về biến môi trường server
        public ItemController(StockDBContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;//dùng cho uploadImage
        }
        public IActionResult Index()
        {
            return View("Login");//thêm này để có thể truy cập file view Login.cshtml bằng /Item mà ko cần sửa đường dẫn trong startup.cs
        }
        [HttpPost]
        public async Task<IActionResult> Login(AccountModel acc)
        {
            if (ModelState.IsValid)//check lỗi khi login sai
            {
                var account = await db.Accounts.SingleOrDefaultAsync(a => a.Username == acc.Username);
                if (account != null && account.Password == acc.Password)
                {
                    //lưu username vào session
                    HttpContext.Session.SetString("username", acc.Username);
                    //chuyển sang trang ListItem
                    return RedirectToAction("ListItem");
                }
                else
                {
                    //ViewData["error"] = "Invalid username or password";
                    ViewBag.error = "Invalid username or password";
                    return View();
                }
            }
            return View();
        }

        
        public async Task<IActionResult> ListItem()
        {
            //check time out session
            if (HttpContext.Session.GetString("username") != null)
            {
                var items = await db.Items.ToListAsync();
                ViewBag.items = items;//dùng viewbag ko dùng @Html đc

                //code hiển thị thông tin account theo username
                var accounts = await db.Accounts.ToListAsync();
                ViewBag.accounts = accounts;
                return View();
            }
            else
            {
                //chuyển về trang login để login lại
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ListItem(ItemModel item)
        {
            if (ModelState.IsValid)//check lỗi validation
            {
                //upload file
                string filename = item.UploadImage.FileName;
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
                await item.UploadImage.CopyToAsync(stream);

                //thêm data vào table Items
                var newItem = new Item { ItemCode = item.ItemCode, ItemName = item.ItemName, Price = item.Price, Image = filename, Username = item.Username };
                db.Items.Add(newItem);
                await db.SaveChangesAsync();
                return RedirectToAction("ListItem");
            }
            //fix lỗi cho hiển thị theo username 
            var items = await db.Items.ToListAsync();
            ViewBag.items = items;//dùng viewbag ko dùng @Html đc

            //code hiển thị thông tin account theo username
            var accounts = await db.Accounts.ToListAsync();
            ViewBag.accounts = accounts;

            return View();
        }
    }
}
