using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC5_Bootstrap3_3_1_LESS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Land a doo about page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Land a doo contact page.";

            return View();
        }

        public ActionResult Team()
        {
            ViewBag.Message = "Land a doo team page.";

            return View();
        }

        public ActionResult Weekly_Update()
        {
            ViewBag.Message = "Weekly updates on Land a Doo.";

            return View();
        }
    }
}