using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Manager.INTERF;
using Web_Project.Storage.Entity;
using Web_Project.ViewsModels;

namespace Web_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAFunctions _funrep;

        public HomeController(IAFunctions funrep)
        {
            _funrep = funrep;
        }
        public IActionResult Index()
        {
            var homefun = new HomeViewModel
            {
                favfunctions = _funrep.getLatFunctions               
            };
            if (User.Identity.IsAuthenticated)
            {
                return Content(User.Identity.Name);
            }
            return View(homefun);
        }

    }
}
