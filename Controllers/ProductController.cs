

using Shop_Asp.Domain;
using Microsoft.AspNetCore.Mvc;


namespace Shop_Asp.Controllers
{
    public class ProductController : Controller
    {

        private readonly DataManager _dataManager;


        public ProductController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }


        public async Task<IActionResult> Index(int id)
        {
            return View(await _dataManager.ProductsRepo.GetProduct(id));
        }
    }
}
