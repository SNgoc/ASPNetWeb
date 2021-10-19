using HomeWork1_News.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork1_News.Controllers
{
    public class NewsController : Controller
    {
        NewsDBContext db;
        public NewsController(NewsDBContext db)
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
            TbAdmin ad = await db.TbAdmins.SingleOrDefaultAsync(a => a.UserName == username && a.Password == password);//check login
            if (ad != null)
            {
                //là admin
                return View("Admin", ad);
            }
            //sai user hoặc pass
            return RedirectToAction("InvalidLogin");
        }

        public IActionResult InvalidLogin()
        {
            return View();
        }

        //show all list customer from db
        public async Task<IActionResult> Show() //show all news
        {
            var news = await db.TbNews.ToListAsync();//show all to list, kiểu dùng trực tiếp model gốc ko qua model trung gian
            return View(news);
        }

        //remove a News from db
        public async Task<IActionResult> Remove() //
        {
            //ViewBag.username = username; session ko cần
            var news = await db.TbNews.ToListAsync();
            return View(news);
        }

        public async Task<IActionResult> Delete(int id)//
        {
            var news = await db.TbNews.SingleOrDefaultAsync(n => n.NewsId == id);
            db.TbNews.Remove(news);
            await db.SaveChangesAsync();//lưu thay đổi vào db
            return RedirectToAction("Remove");
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
        public async Task<IActionResult> Create(TbNews news)//tạo hàm có parameter là đối tượng news
        {
            news = new TbNews { NewsId = news.NewsId, HeadLines = news.HeadLines, ContentOfNews = news.ContentOfNews };
            db.TbNews.Add(news);
            await db.SaveChangesAsync();//lưu thay đổi vào db
            return RedirectToAction("Show"); //chuyền về trang show khi create thành công
            //dùng các hàm có Async cuối => performance tăng
        }
    }
}
