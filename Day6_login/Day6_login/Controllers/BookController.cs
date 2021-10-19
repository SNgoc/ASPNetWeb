using Day6_login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day6_login.Controllers
{
    public class BookController : Controller
    {
        //khai báo đối tượng bookdata để hiển thị
        BookData context = new BookData();
        // GET: Book
        public ActionResult Index()
        {
            return View(context.Books);//hiển thị data books
        }

        [Authorize]//
        public ActionResult Create()
        {
            return View();//hiển thị data books
        }

        [Authorize]
        [HttpPost]//dùng post
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)//nếu đáp ứng
            {
                context.Create(book);
                return RedirectToAction("Index", "Book");//chuyển trang về index trong thư mục Book của view dùng và hiển thị Book đã update
            }
            return View();
        }
    }
}