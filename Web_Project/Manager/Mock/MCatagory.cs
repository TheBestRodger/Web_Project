using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Manager.INTERF;
using Web_Project.Storage.Entity;

namespace Web_Project.Manager.Mock
{
    public class MCatagory : IFunctionsManager
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {catName = "Математика", desc = "Разные мат.формулы"},
                    new Category {catName = "Физика", desc = "Разные физ.формулы"}

                };
            }

        }
    }
}
