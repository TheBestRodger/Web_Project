using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Manager.INTERF;
using Web_Project.Storage.Entity;
using Web_Project.ViewsModels;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;
using Web_Project.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Web_Project.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationContext db;
        private readonly IAllOrders allOrders;
        private readonly NPage npage;
        private readonly UserManager<Order> _userManager;
        private readonly SignInManager<Order> _signInManager;
        public OrderController(ApplicationContext context, IAllOrders allOrders, NPage npage)
        {
            db = context;
            this.allOrders = allOrders;
            this.npage = npage;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Order order = await db.Orders.FirstOrDefaultAsync(u => u.mail == model.mail && u.Password == model.Password);
                if (order != null)
                {
                    await Authenticate(model.mail); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                Order order = await db.Orders.FirstOrDefaultAsync(u => u.mail == model.mail);
                if (order == null)
                {
                    // добавляем пользователя в бд
                    db.Orders.Add(new Order { mail = model.mail, Password = model.Password});
                    await db.SaveChangesAsync();

                    await Authenticate(model.mail); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
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
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
