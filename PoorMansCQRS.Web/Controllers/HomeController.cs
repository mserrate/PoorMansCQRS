using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoorMansCQRS.Commands;
using PoorMansCQRS.Infrastructure;
using PoorMansCQRS.ReadModel;

namespace PoorMansCQRS.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
    }
}
