

using Shop_Asp.Domain;
using Shop_Asp.Domain.Entities;
using Shop_Asp.Domain.Helpers;

using Microsoft.AspNetCore.Mvc;


namespace Shop_Asp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShopModelsController : Controller
    {


        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        private ShopModel _shopModels;


        public ShopModelsController(DataManager dataManager,
                                    IWebHostEnvironment hostEnvironment)
        {
            _dataManager = dataManager;
            _hostEnvironment = hostEnvironment;
            _shopModels = new ShopModel();
        }


        public IActionResult ShopEdit()
        {
            if (_dataManager.ShopRepo != null)
            {
                _shopModels = _dataManager.ShopRepo.GetShopData().ToList()[0];
                return View(_shopModels);
            }
            else
            {
                return Problem("Entity set 'ApplicationContext.ShopModels'  is null.");
            }
        }


        [HttpPost]
        public async Task<IActionResult> ShopEdit(ShopModel shop, IFormFile LogoImgPath)
        {

           // if (ModelState.IsValid && LogoImgPath != null)
          //  {
                shop.LogoImgPath = LogoImgPath.FileName;
                using (var stream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath,
                                                 "Images/", LogoImgPath.FileName), FileMode.Create))
                {
                    LogoImgPath.CopyTo(stream);
                }

                if (await _dataManager.ShopRepo.SaveShopData(shop) > 0)
                {
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
                }
          //  }
           // Debug.WriteLine("SSSSSSSSSSSS");
            return View(_shopModels);
        }
    }
}
