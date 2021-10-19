using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAuthen.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/product")]
    public class ProductController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
