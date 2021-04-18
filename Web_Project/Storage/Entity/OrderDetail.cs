using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Project.Storage.Entity
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int OrdeID { get; set; }
        public int FunID { get; set; }
        public virtual Functions functions { get; set; }
        public virtual Order order { get; set; }
        
    }
}
