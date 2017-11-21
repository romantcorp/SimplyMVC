using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication9.Controllers
{
    public class write : Controller
    {
        // GET: write
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult SomeMethod()
        {
            ViewData["Head"] = "Привет мир!";
            return View("SomeView");
        }
    }
}