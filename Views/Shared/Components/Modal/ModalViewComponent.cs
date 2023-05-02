

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Diagnostics;


namespace Shop_Asp.Views.Shared.Components.Modal
{
    public class ModalViewComponent : ViewComponent
    {

        public ModalViewComponent()
        {
            
        }

        public IViewComponentResult Invoke(IHtmlContent parameters, bool isMessage = false)
        {
            ViewBag.IsMessage = isMessage;
            return View("ModalViewComponent", parameters);
        }

    }
}
