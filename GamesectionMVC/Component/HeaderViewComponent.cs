using System;
using System.Linq;
using BussinessLogic.Abstract;
using Core.BLL.Constant;
using Entity.POCO;
using GamesectionMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GamesectionMVC.Component
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;
       

        public HeaderViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
            
        }

        public IViewComponentResult Invoke()
        {
            HeaderViewModel model = new HeaderViewModel();
           
            
                var categories = categoryService.GetAllActive();
                switch (categories.ResultType)
                {
                    case EntityResultType.Success:
                        model.Category = categories.Data.ToList();
                        break;
                    case EntityResultType.Error:
                        break;
                    case EntityResultType.Notfound:
                        break;
                    case EntityResultType.NonValidation:
                        break;
                    case EntityResultType.Warning:
                        break;
                    default:
                        break;
                }
                return View(model);
            
        }
    }
}
