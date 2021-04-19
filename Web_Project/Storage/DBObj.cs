using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Storage.Entity;

namespace Web_Project.Storage
{
    public class DBObj
    {
        public static void initial(AppDBContent content)
        {

            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
            if (!content.Functions.Any())
            {
                content.AddRange(
                    new Functions
                    {
                        name = "Алгебра",
                        shortDecs = "",
                        longDecs = "",
                        isFavor = true,
                        img = "/img/1.jpg",
                        Category = Categories["Математика"]
                    },
                     new Functions
                     {
                         name = "Геометрия",
                         shortDecs = "",
                         longDecs = "",
                         isFavor = false,
                         img = "/img/2.jpg",
                         Category = Categories["Математика"]
                     },
                      new Functions
                      {
                          name = "Физика",
                          shortDecs = "",
                          longDecs = "",
                          isFavor = true,
                          img = "/img/3.jpg",
                          Category = Categories["Физика"]
                      });
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                         new Category {catName = "Математика", desc = "Разные мат.формулы"},
                         new Category {catName = "Физика", desc = "Разные физ.формулы"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.catName, el);
                }
                return category;
            }

        }

    }
}
