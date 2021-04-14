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
    public class PageCartController : Controller
    {
        private readonly IAFunctions _funrep;
        private readonly NPage _npage;
        public PageCartController(IAFunctions funrep, NPage npage)
        {
            _funrep = funrep;
            _npage = npage;
        }

        public ViewResult Index()
        {
            var items = _npage.getPageItems();
            _npage.listNewPage = items;
            var obj = new PageCartViewModel
            {
                npage = _npage
            };
            return View(obj);
        }

        public RedirectToActionResult addtoCart(int id)
        {
            var item = _funrep.Functions.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _npage.AddToPage(item);
            }
            return RedirectToAction("Index");

        }
    }
}
