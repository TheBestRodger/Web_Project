using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Manager.INTERF;
using Web_Project.Storage.Entity;
using Web_Project.ViewsModels;
using Microsoft.AspNetCore.Identity;

namespace Web_Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly NPage npage;
        private readonly UserManager<Order> _userManager;
        private readonly SignInManager<Order> _signInManager;
        public OrderController(IAllOrders allOrders, NPage npage)
        {
            this.allOrders = allOrders;
            this.npage = npage;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Order order)
        {
            
                Order user = new Order { mail = order.mail, id = order.id, name = order.name,
                surname=order.surname, adress=order.adress, phone=order.phone};
                

                //добавляем пользователя
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    //куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            
            return View(order);
        }
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
