

using Shop_Asp.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Shop_Asp.Controllers
{

    public class IdentityController : Controller
    {


        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> signInManager;


        public IdentityController(UserManager<IdentityUser> userMgr,
                                 SignInManager<IdentityUser> signinMgr)
        {
            _userManager = userMgr;
            signInManager = signinMgr;
        }


        
    }
}
