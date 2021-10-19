using DemoASPNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoASPNetCoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly T12008M0Context db;
        //inject đối tượng T12008M0Context đã đc load lên trong method ConfigureServices() của tập tin Startup.cs
        public CustomerController(T12008M0Context db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
