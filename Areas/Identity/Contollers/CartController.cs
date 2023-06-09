﻿

using Shop_Asp.Domain;
using Shop_Asp.Domain.Helpers;
using Shop_Asp.Domain.Entities;
using Shop_Asp.Models.CartCheckOutModel;
using Shop_Asp.Views.Shared.CustomActionResults;

using Newtonsoft.Json;

using Microsoft.AspNetCore.Mvc;


namespace Shop_Asp.Areas.Identity.Contollers
{
    [Area("Identity")]
    public class CartController : Controller
    {


        private readonly DataManager _dataManager;


        public CartController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }


        public IActionResult Index()
        {
            if (!HttpContext.Session.Get<bool>("IsLogin"))
            {
                return Redirect(Url.Content("~/Home/AuthUser"));
            }

            return View(_dataManager.CartRepo.GetProducts());
        }


        [HttpPost]
        public IActionResult Index(int id)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SelectOrderData(int id)
        {
            if (!HttpContext.Session.Get<bool>("IsLogin"))
            {
                return Ok("No");
            }
            var product = await _dataManager.ProductsRepo.GetProduct(id);
            return new SelectOrderResult(product);
        }


        [HttpPost]
        public async Task<IActionResult> CartAddData(int productId, int quantity, string color, int size)
        {
            if (!HttpContext.Session.Get<bool>("IsLogin"))
            {
                return Ok("No");
            }

            var cart = new Cart()
            {
                Email = HttpContext.Session.Get<string>("UserEmail"),
                ProductId = productId,
                BuyCount = quantity,
                Color = color,
                Size = size.ToString(),
                Status = 1
            };

            if (_dataManager.CartRepo.AddUpdateOrder(cart) < 1)
            {
                return Ok("NoSave");
            }
            //  var product = await _dataManager.ProductsRepo.GetProduct(productId);
            List<Cart> carts = _dataManager.CartRepo.GetProducts();
            HttpContext.Session.Set<List<Cart>>("UserCart", carts);
            return Ok("Ok");
        }


        [HttpPost]
        public IActionResult CheckoutOrder([FromBody] object param)
        {
            if (!HttpContext.Session.Get<bool>("IsLogin"))
            {
                return Ok("No");
            }

            var str = param.ToString();
            if (str != null)
            {
                var carts = HttpContext.Session.Get<List<Cart>>("UserCart");
                var a = JsonConvert.DeserializeObject<AjaxCheckoutCart>(str);

                // изменить в базе если были изменения
                bool isChange = false;
                foreach (var item in carts)
                {
                    foreach (var it in a.Quantity_Id)
                    {
                        if(item.Id == it.id && item.BuyCount != it.quantity)
                        {
                            item.BuyCount = it.quantity;
                           if(_dataManager.CartRepo.AddUpdateOrder(item) <= 0)
                            {
                                return Ok("NoSave");
                            }
                            isChange = true;
                        }
                    }
                }

                if (isChange)
                {
                    HttpContext.Session.Set<List<Cart>>("UserCart", carts);
                }

                HttpContext.Session.Set<int>("TotalsumCart", a.TotalSum);

                return Ok("Ok");
            }
            return Ok("NoSave");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (!HttpContext.Session.Get<bool>("IsLogin"))
            {
                return Ok("No");
            }

            if (await _dataManager.CartRepo.DeleteOrderAsync(id) > 0)
            {
                List<Cart> carts = _dataManager.CartRepo.GetProducts();
                HttpContext.Session.Set<List<Cart>>("UserCart", carts);
                return Ok("Ok");
            }

            return Ok("NoSave");
        }
    }
}
