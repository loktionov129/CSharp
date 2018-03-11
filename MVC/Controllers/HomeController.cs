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

        [HttpGet]
        public ActionResult Ajax()
        {
            ViewBag.active = "All";
            return View();
        }

        [HttpPost]
        public ActionResult Ajax(string active)
        {
            ViewBag.active = active;
            return View();
        }

        public PartialViewResult GetItems(string active)
        {
            var items = new[]
            {
                new Class1() { Id = 1, Col1 = "Active" },
                new Class1() { Id = 2, Col1 = "Passive" },
                new Class1() { Id = 3, Col1 = "Active" }
            };

            return PartialView(active == "All" ? items : items.Where(x => x.Col1 == active));
        }
    }
}