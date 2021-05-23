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
                        name = "Градиент",
                        shortDecs = "https://localhost:44393/Gradient/List",
                        longDecs = "",
                        isFavor = true,
                        img = "/img/7.jpg",
                        Category = Categories["Математика"]
                    },
                     new Functions
                     {
                         name = "Производная",
                         shortDecs = "https://localhost:44393/Derivative/List",
                         longDecs = "",
                         isFavor = true,
                         img = "/img/8.jpg",
                         Category = Categories["Математика"]
                     },
                      new Functions
                      {
                          name = "Частные производные",
                          shortDecs = "https://localhost:44393/Partial_Derivatives/List",
                          longDecs = "",
                          isFavor = true,
                          img = "/img/9.jpg",
                          Category = Categories["Математика"]
                      },
                     new Functions
                     {
                         name = "Метод Зейделя",
                         shortDecs = "https://localhost:44393/Seidel_Method/List",
                         longDecs = "",
                         isFavor = true,
                         img = "/img/4.jpg",
                         Category = Categories["Математика"]
                     },
                       new Functions
                       {
                           name = "Метод Гаусса",
                           shortDecs = "https://localhost:44393/Gauss_Method/List",
                           longDecs = "",
                           isFavor = true,
                           img = "/img/5.jpg",
                           Category = Categories["Математика"]
                       },
                     new Functions
                     {
                         name = "Определитель матрицы",
                         shortDecs = "https://localhost:44393/Matrix_Determinant/List",
                         longDecs = "",
                         isFavor = true,
                         img = "/img/6.jpg",
                         Category = Categories["Математика"]
                     }

                    );
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
