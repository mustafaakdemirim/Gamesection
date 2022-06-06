using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.POCO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamesectionMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/")]
    public class AdminAccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AdminAccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        //[HttpGet]
        //public async Task<IActionResult> Login(string ReturnURL)
        //{
            //TempData["retnUrl"] = ReturnURL;
            //return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var sign = await signInManager.PasswordSignInAsync(userName, password, false, false);

            if (sign.Succeeded)
            {
                if (TempData["retnUrl"] != null)
                {
                    return Redirect(TempData["retnUrl"].ToString());
                }
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
        public async Task<IActionResult> Exit()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}