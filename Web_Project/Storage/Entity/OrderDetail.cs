using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Project.Storage.Entity
{
    public class OrderDetail
    {   [Required]
        public int id { get; set; }
        [Required]
        public int OrdeID { get; set; }
        [Required]
        public int FunID { get; set; }
        public virtual Functions functions { get; set; }
        public virtual Order order { get; set; }
        
    }
}
