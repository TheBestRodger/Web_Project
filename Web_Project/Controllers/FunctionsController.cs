using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Manager.INTERF;
using Web_Project.ViewsModels;

namespace Web_Project.Controllers
{
    public class FunctionsController : Controller
    {
        private readonly IAFunctions _allFun;
        private readonly IFunctionsManager _allCat;

        public FunctionsController(IAFunctions iAllFun, IFunctionsManager iAllCat)
        {

            _allFun = iAllFun;
            _allCat = iAllCat;

        }

        public ViewResult List()
        {

            
            //var fun = _allFun.Functions;
            ViewBag.Title = "Страница с функциями";
            FunctionsListViewModel obj = new FunctionsListViewModel();
            obj.AllFun = _allFun.Functions;
            obj.currCategory = "";
            return View(obj);
        }


    }
}
