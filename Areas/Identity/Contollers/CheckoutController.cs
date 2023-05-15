

using Shop_Asp.Domain;
using Shop_Asp.Domain.Helpers;
using Shop_Asp.Domain.Entities;

using Microsoft.AspNetCore.Mvc;


namespace Shop_Asp.Areas.Identity.Contollers
{

    [Area("Identity")]
    public class CheckoutController : Controller
    {


        private readonly DataManager _dataManager;


        public CheckoutController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Checkout()
        {
            if (!HttpContext.Session.Get<bool>("IsLogin"))
            {
                return Redirect(Url.Content("~/Home/AuthUser"));
            }

           var email = HttpContext.Session.Get<string>("UserEmail");
           var account = await _dataManager.LoginRepo.GetUserAccount(email);

            return View(account);
        }

        [HttpPost]
        public async Task Checkout([FromBody] object query)
        {
            HttpContext.Session.Set<int>("TotalsumCart", 0);
        }
    }
}
