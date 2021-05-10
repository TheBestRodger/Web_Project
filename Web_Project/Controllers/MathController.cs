using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Manager.INTERF;
using Web_Project.ViewsModels;

namespace Web_Project.Controllers
{
    public class MathController : Controller
    {
        private readonly IAFunctions _funrep;
        public MathController(IAFunctions funrep)
        {
            _funrep = funrep;
        }
        public IActionResult Index()
        {
            var homefun = new HomeViewModel
            {
                favfunctions = _funrep.MathCat
            };

            return View(homefun);
        }
    }
}
