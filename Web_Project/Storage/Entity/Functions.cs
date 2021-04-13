using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Project.Storage.Entity
{
    public class Functions
    {

        public int id { get; set; }
        public string name { get; set; }
        public string shortDecs { get; set; }
        public string longDecs { get; set; }
        public string img { get; set; }
        public bool isFavor { get; set; }
        public int CaregoryId { get; set; }
        public virtual Category Category { get; set;}

   


    }
}
