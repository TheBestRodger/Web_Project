using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Manager.INTERF;
using Web_Project.Storage.Entity;

namespace Web_Project.Storage.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly NPage npage;

        public OrdersRepository(AppDBContent appDBContent, NPage npage)
        {
            this.appDBContent = appDBContent;
            this.npage = npage;
        }
        public void creatOrder(Order order)
        {
            order.ordertime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();
            var items = npage.listNewPage;

            foreach(var el in items)
            {
                var OrdeDetail = new OrderDetail()
                {
                    FunID = el.Functions.id,
                    OrdeID = order.id
                };
                appDBContent.OrderDetail.Add(OrdeDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
