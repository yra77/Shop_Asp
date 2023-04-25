

using Shop_Asp.Domain.Entities;
using Shop_Asp.Domain.Helpers;
using Shop_Asp.Domain;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Shop_Asp.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class BrandsController : Controller
    {


        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostEnvironment;


        public BrandsController(DataManager dataManager,
                                IWebHostEnvironment hostEnvironment)
        {
            _dataManager = dataManager;
            _hostEnvironment = hostEnvironment;
        }


        public IActionResult BrandsEdit()
        {
            return View(_dataManager.BrandsRepo.GetBrands());
        }

        public IActionResult BrandCreate()
        {
            return View(new Brand());
        }

        [HttpPost]
        public async Task<IActionResult> BrandDelete(int id)
        {
            if (await _dataManager.BrandsRepo.DeleteBrandAsync(id) > 0)
            {
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return Problem("Entity set 'ApplicationContext.Product`s'  is null.");
        }

        [HttpPost]
        public async Task<IActionResult> BrandsEdit(Brand item, IFormFile BrandImgPath)
        {
           
            item.LogoBrands = BrandImgPath.FileName;
            //using (var stream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath,
            //                                 "Images/", BrandImgPath.FileName), FileMode.Create))
            //{
            //    BrandImgPath.CopyTo(stream);
            //}

            if (await _dataManager.BrandsRepo.Add_Update_BrandAsync(item) > 0)
            {
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return Problem("Entity set 'ApplicationContext.Product`s'  is null.");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BrandCreate(Brand item, IFormFile BrandImgPath)
        {
            item.LogoBrands = BrandImgPath.FileName;

            //using (var stream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath,
            //                                 "Images/", BrandImgPath.FileName), FileMode.Create))
            //{
            //    BrandImgPath.CopyTo(stream);
            //}

            if (await _dataManager.BrandsRepo.Add_Update_BrandAsync(item) > 0)
            {
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return Problem("Entity set 'ApplicationContext.Product`s'  is null.");
        }

    }
}
