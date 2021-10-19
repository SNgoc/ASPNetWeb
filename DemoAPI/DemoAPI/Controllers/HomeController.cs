using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAPI.Controllers
{
    public class HomeController : Controller
    {
        T12008M0Entities db = new T12008M0Entities();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            List<Customer> customer = db.Customers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult UsePost()
        {

            return View();
        }
    }
}
