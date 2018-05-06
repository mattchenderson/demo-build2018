using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinuxAuthDemo.Models;

namespace LinuxAuthDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var foo = Request.Headers.Keys.ToList<string>();
            var model = new List<Header>();
            foreach (var key in foo)
            {
                model.Add(new Header {Key = key, Value = Request.Headers[key]});
            }
            ViewData["Message"] = "Your application description page.";

            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
