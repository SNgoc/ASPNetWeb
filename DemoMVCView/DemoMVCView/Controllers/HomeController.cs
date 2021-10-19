using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVCView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult HtmlMethod()
        {
            return View();
        }

        public ActionResult DemoViewData()
        {
            ViewData["Name"] = "Nero"; //sử dụng cú pháp indexer của C# - value này chỉ tồn tại trong demoviewdata
            return View();
            //return RedirectToAction("HtmlMethod"); //chuyển đến trang htmlmethod
        }
    }
}