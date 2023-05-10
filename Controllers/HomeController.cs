

using Shop_Asp.Models;
using Shop_Asp.Domain;
using Shop_Asp.Domain.Helpers;
using Shop_Asp.Domain.Entities;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


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

        public IActionResult About()
        {
            return View();
        }

        public IActionResult AuthUser()
        {
            // ViewBag.returnUrl = Url.Content("~/");
            return View(new Login());
        }


        [HttpPost]
        public IActionResult AuthUser([FromBody] Login model)
        {
            try
            {
                var result = _dataManager.LoginRepo.GetLogin(model);
                if (result != null)
                {
                    List<Cart> carts = _dataManager.CartRepo.GetProducts();
                    HttpContext.Session.Set<List<Cart>>("UserCart", carts);
                    HttpContext.Session.Set<string>("UserEmail", model.Email);
                    HttpContext.Session.Set<bool>("IsLogin", true);
                    return this.Ok("Ok");// RedirectToAction("AuthUser", "Home");
                }
                else
                {
                    HttpContext.Session.Set<List<Cart>>("UserCart", new List<Cart>());
                    HttpContext.Session.Set<string>("UserEmail", "");
                    HttpContext.Session.Set<bool>("IsLogin", false);
                    ModelState.AddModelError(nameof(Login.Email), "Неверный логин или пароль");
                    return Ok("No");
                }
            }
            catch
            {
                return Ok("No");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AuthUserCreate([FromBody] Login user)
        {
            try
            {
                var result = await _dataManager.LoginRepo.AddUpdateLogin(user);

                if (result > 0)
                {
                    _logger.LogInformation("User created a new account with password.");
                    List<Cart> carts = _dataManager.CartRepo.GetProducts();
                    HttpContext.Session.Set<List<Cart>>("UserCart", carts);
                    HttpContext.Session.Set<string>("UserEmail", user.Email);
                    HttpContext.Session.Set<bool>("IsLogin", true);
                    return this.Ok("Ok");
                }
                else
                {
                    HttpContext.Session.Set<List<Cart>>("UserCart", new List<Cart>());
                    HttpContext.Session.Set<string>("UserEmail", "");
                    HttpContext.Session.Set<bool>("IsLogin", false);

                    return this.Ok("No");// ModelState.AddModelError(nameof(Login.Email), "Неверный логин или пароль");
                }
            }
            catch
            {
                HttpContext.Session.Set<List<Cart>>("UserCart", new List<Cart>());
                HttpContext.Session.Set<string>("UserEmail", "");
                HttpContext.Session.Set<bool>("IsLogin", false);
                return this.Ok("No");
            }
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Set<List<Cart>>("UserCart", new List<Cart>());
            HttpContext.Session.Set<string>("UserEmail", "");
            HttpContext.Session.Set<bool>("IsLogin", false);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}