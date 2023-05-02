

using Microsoft.AspNetCore.Mvc;


namespace Shop_Asp.Views.Shared.Components.RangeSlider
{
    public class RangeSliderViewComponent : ViewComponent
    {

        public RangeSliderViewComponent() { }


        public IViewComponentResult Invoke(int min, int max)
        {
            ViewBag.Min = min;
            ViewBag.Max = max;
            return View("RangeSliderViewComponent");
        }
    }
}
