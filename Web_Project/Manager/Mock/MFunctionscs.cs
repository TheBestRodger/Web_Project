using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Manager.INTERF;
using Web_Project.Storage.Entity;

namespace Web_Project.Manager.Mock
{
    public class MFunctionscs : IAFunctions
    {
        private readonly IFunctionsManager _functions = new MCatagory();
        public IEnumerable<Functions> Functions { get {
                return new List<Functions>
                {
                    new Functions{ 
                        name = "Алгебра", 
                        shortDecs = "", 
                        longDecs = "", 
                        isFavor =  true, img = "/img/1.jpg", 
                        Category = _functions.AllCategories.First()
                    },
                     new Functions{
                        name = "Геометрия",
                        shortDecs = "",
                        longDecs = "",
                        isFavor =  false, img = "/img/2.jpg",
                        Category = _functions.AllCategories.Last()
                    },
                      new Functions{
                        name = "Физика",
                        shortDecs = "",
                        longDecs = "",
                        isFavor =  true, img = "/img/3.jpg",
                        Category = _functions.AllCategories.First()
                    },
                     new Functions{
                        name = "Кинетическая энергия",
                        shortDecs = "E = MV*MV / 2",
                        longDecs = "M - масса тела, V - скорость тела",
                        isFavor =  false, img = "/img/1.jpg",
                        Category = _functions.AllCategories.Last()
                    },
                       new Functions{
                        name = "Умножение",
                        shortDecs = "2*3 = 6",
                        longDecs = "не требуется",
                        isFavor =  true, img = "/img/1.jpg",
                        Category = _functions.AllCategories.First()
                    },
                     new Functions{
                        name = "Потенциальная энергия",
                        shortDecs = "E = mgh",
                        longDecs = "m - масса тела, g - 9.98, h - высота",
                        isFavor =  false, img = "/img/1.jpg",
                        Category = _functions.AllCategories.Last()
                    }


                };
            }
            }
        public IEnumerable<Functions> getLatFunctions { get ;set; }

        public IEnumerable<Functions> MathCat { get; set; }

        public IEnumerable<Functions> PhyCat { get; set; }

        public Functions getFun(int funId)
        {
            throw new NotImplementedException();
        }
    }
}
