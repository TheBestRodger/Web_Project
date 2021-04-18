using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Manager.INTERF;
using Web_Project.Storage.Entity;

namespace Web_Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly NPage npage;

        public OrderController(IAllOrders allOrders, NPage npage)
        {
            this.allOrders = allOrders;
            this.npage = npage;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            npage.listNewPage = npage.getPageItems();
            if(npage.listNewPage.Count == 0)
            {
                ModelState.AddModelError("", "Как так-то");
            }
            if (ModelState.IsValid)
            {
                allOrders.creatOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
         {
            return View();
         }
    }
}
