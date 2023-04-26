

using Shop_Asp.Models;
using Shop_Asp.Domain;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Shop_Asp.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;
        private readonly DataManager _dataManager;


        public HomeController(ILogger<HomeController> logger,
                              DataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
        }


        public IActionResult Index()
        {
            var arr = _dataManager.ProductsRepo.GetProducts();
            ViewBag.NewProducts = arr.Where(x => x.IsNew == true).ToList();
            ViewBag.BestProducts = arr.Where(x => x.IsBestSeller == true).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}