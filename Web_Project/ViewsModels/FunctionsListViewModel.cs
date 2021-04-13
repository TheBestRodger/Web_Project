using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Storage.Entity;

namespace Web_Project.ViewsModels
{
    public class FunctionsListViewModel
    {
        public IEnumerable<Functions> AllFun { get; set; }

        public string currCategory { get; set; }
    }
}
