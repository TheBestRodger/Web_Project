using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Project.Storage.Entity
{
    public class Category
    {
        public int id { set; get; }
        public string catName { set; get; }
        public string desc { get; set; }
        public List<Functions> Functions { get; set; }

    }
}
