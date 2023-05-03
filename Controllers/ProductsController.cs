

using Shop_Asp.Domain;
using Shop_Asp.Models;
using Shop_Asp.Domain.Entities;
using Shop_Asp.Domain.Helpers;

using Newtonsoft.Json;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Shop_Asp.Controllers
{
    public class ProductsController : Controller
    {


        private DataManager _dataManager;
        private static List<Product> _filters = new List<Product>();
        private static bool _isFilter = false;


        public ProductsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }


        public IActionResult Index(string? id = null)//id == brand name
        {
            try
            {
                if (_isFilter)
                {
                    _isFilter = false;
                    return View(_filters);
                }

                if (id != null)//id == brand name
                {
                    return View(_dataManager.ProductsRepo.GetProducts()
                             .Where(x => x.Brand.ToLower() == id.ToLower()));
                }
                else
                {
                    return View(_dataManager.ProductsRepo.GetProducts());
                }
            }
            catch
            {
                return Problem("Entity set 'ApplicationContext.Product`s'  is null.");
            }
        }


        [HttpPost]
        public IActionResult Index([FromBody] object response)
        {
            if (response != null)
            {
                FilterModel filterData = JsonConvert.DeserializeObject<FilterModel>(response.ToString());
                
                FilerSearch(filterData);

                _isFilter = true;

                return Json(new { resut = "OK" });
            }
            return Json(new { resut = "No" });
        }

        private void FilerSearch(FilterModel filterData)
        {
            _filters = _dataManager.ProductsRepo.GetProducts();
           
            if (filterData.SearchStr != null && filterData.SearchStr.Count() > 0)//search name or brand
            {
                _filters = new List<Product>(_filters.AsParallel()
                    .Where(s => s.Name.ToLower() == filterData.SearchStr.ToLower()
                             || s.Brand.ToLower() == filterData.SearchStr.ToLower()));
                return;
            }

            if (filterData.Brands != null && filterData.Brands.Count > 0)
            {
                _filters = new List<Product>(_filters.AsParallel()
                    .Where(s => filterData.Brands.Any(ss => s.Brand.ToLower() == ss.ToLower())));
            }

            if (filterData.Genders != null && filterData.Genders.Count > 0)
            {
                _filters = new List<Product>(_filters.AsParallel()
                    .Where(s => filterData.Genders.Any(ss => s.Gender.ToLower() == ss.ToLower())));
            }

            if (filterData.Sizes != null && filterData.Sizes.Count > 0)
            {
                _filters = new List<Product>(_filters.AsParallel()
                    .Where(s => filterData.Sizes.Any(ss => s.Sizes.Split(' ').Any(a => a == ss))));

            }

            int max = Int32.Parse(filterData.MinMaxPrice[1]);
            int min = Int32.Parse(filterData.MinMaxPrice[0]);

            if (max > 60 && _filters != null && _filters.Count > 0)
            {
                _filters = new List<Product>(_filters.AsParallel().Where(s => s.Price >= min && s.Price <= max));
                if (_filters == null || _filters.Count == 0)
                {
                    HttpContext.Session.Set<string>("NotFoundSize", "Increase the price.");
                }
            }

            if (_filters == null || _filters.Count == 0)
            {
                HttpContext.Session.Set<string>("NotFound", "Change your search options.");
            }
        }
    }

}

