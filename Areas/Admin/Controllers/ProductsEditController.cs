

using Shop_Asp.Domain;
using Shop_Asp.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using Shop_Asp.Domain.Helpers;


namespace Shop_Asp.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductsEditController : Controller
    {


        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        private List<Product> _products;


        public ProductsEditController(DataManager dataManager,
                                      IWebHostEnvironment hostEnvironment)
        {
            _dataManager = dataManager;
            _hostEnvironment = hostEnvironment;
            _products = new List<Product>();
        }
        

        public IActionResult ProductsEdit()
        {
            if (_dataManager.ProductsRepo != null)
            {
                _products = _dataManager.ProductsRepo.GetProducts();
                return View(_products);
            }
            else
            {
                return Problem("Entity set 'ApplicationContext.Product`s'  is null.");
            }
        }

        public async Task<IActionResult> ProductCreate(int id = -1)
        {
            var entity = id == -1 ? new Product() : await _dataManager.ProductsRepo.GetProduct(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductCreate(Product item, List<IFormFile> ProdImgPath)
        {
            if (ModelState.IsValid)
            {
                List<Photo> photo = new List<Photo>();
            
                foreach (var item1 in ProdImgPath)
                {
                    photo.Add(new Photo()
                    {
                        Image = "productPhoto/" + item.Brand.ToLower() + "/" + item1.FileName
                    });

                    //using (var stream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath,
                    //                                 "productPhoto/" + item.Brand.ToLower() + "/",
                    //                                 item1.FileName), FileMode.Create))
                    //{
                    //    item1.CopyTo(stream);
                    //}
                }

                item.Photos_Large = new List<Photo>(photo);

                //_products.Add(item);

                if (_dataManager.ProductsRepo.SaveProduct(item) > 0)
                {
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
                }
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(int id)
        {
            if (await _dataManager.ProductsRepo.DeleteProduct(id) > 0)
            {
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return Problem("Entity set 'ApplicationContext.Product`s'  is null.");
        }
    }
}
