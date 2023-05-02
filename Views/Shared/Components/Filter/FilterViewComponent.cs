

using Microsoft.AspNetCore.Mvc;
using Shop_Asp.Domain;
using Shop_Asp.Models;


namespace Shop_Asp.Views.Shared.Components.Filter
{
    public class FilterViewComponent : ViewComponent
    {


        private readonly DataManager _dataManager;


        public FilterViewComponent(DataManager dataManager)
        {
            _dataManager = dataManager;
        }


        public IViewComponentResult Invoke()
        {

            ViewBag.Brands = _dataManager.BrandsRepo.GetBrands();
            ViewBag.Colors = new Colors(); 
            ViewBag.Sizes = new Sizes();

            return View("FilterViewComponent");
        }
    }
}
