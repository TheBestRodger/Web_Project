﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Project.Controllers
{
    public class Refraction_LightController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
