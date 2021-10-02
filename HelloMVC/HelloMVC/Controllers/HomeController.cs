using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HelloMVC.Controllers
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
        //public ActionResult SayHello()
        //{
        //    return View();//con trỏ trong hàm + click chuột phải
        //}
        public Task<ActionResult> SayHello()
        {
            return View();//con trỏ trong hàm + click chuột phải
        }
    }
}