﻿using Microsoft.AspNetCore.Mvc;

namespace Travel.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
