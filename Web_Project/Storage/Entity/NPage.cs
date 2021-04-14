using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Project.Storage.Entity
{
    public class NPage
    {
        private readonly AppDBContent appDBContent;
        public NPage(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string PageId { get; set; }
        public List<NewPage> listNewPage { get; set; }
        public static NPage GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string PageCartId = session.GetString("cartId") ?? Guid.NewGuid().ToString();
            session.SetString("cartId", PageCartId);

            return new NPage(context) { PageId = PageCartId };
        }

        public void AddToPage (Functions functions)
        {

            appDBContent.PageItem.Add(new NewPage
            {
                WebPage = PageId,
                Functions = functions
            });
            appDBContent.SaveChanges();

        }
        public List<NewPage> getPageItems()
        {
            return appDBContent.PageItem.Where(c => c.WebPage == PageId).Include(s => s.Functions).ToList();
        }
    }
}
