﻿using Microsoft.AspNetCore.Mvc;

namespace FlightPlannerC3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
