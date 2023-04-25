

using Shop_Asp.Domain;
using Microsoft.AspNetCore.Mvc;


namespace Shop_Asp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {


        private DataManager _dataManager;


        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
