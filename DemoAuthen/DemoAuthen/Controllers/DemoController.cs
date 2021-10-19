using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAuthen.Controllers
{
    [Route("demo")]

    public class DemoController : Controller
    {
        [Route("")]
        [Route("/")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
