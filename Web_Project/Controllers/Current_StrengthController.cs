using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Project.Controllers
{
    public class Current_StrengthController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
