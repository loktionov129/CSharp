using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testAsp.Controllers
{
    using testAsp.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Y0ur @pplication description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            return View(new Class1());
        }

        [HttpPost]
        public ActionResult Test(Class1 data)
        {
            return ModelState.IsValid ? View("Success", data) : View();
        }
    }
}