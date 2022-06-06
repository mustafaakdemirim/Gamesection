using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BussinessLogic.Abstract;
using Entity.POCO;
using GamesectionMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace GamesectionMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ICartService cartService;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,ICartService cartService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.cartService = cartService;
        }
        [HttpGet]
        public async Task<IActionResult> Signin(string ReturnURL)
        {
            TempData["retnUrl"] = ReturnURL;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signin(string userName, string password)
        {
            var sign = await signInManager.PasswordSignInAsync(userName, password, false, false);
           
            if (sign.Succeeded)
            {
                if (TempData["retnUrl"] != null)
                {
                    return Redirect(TempData["retnUrl"].ToString());
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    Email = model.Email,
                    UserName=model.UserName
                };
                var ıdentityResult = await userManager.CreateAsync(appUser, model.Password);
                
                if (!ıdentityResult.Succeeded)
                {
                    foreach (var item in ıdentityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);
                }
                else
                {
                    await userManager.AddToRoleAsync(appUser, "UserApp");
                }
            }
            return RedirectToAction("Signin");
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            
            var appUser = await userManager.FindByNameAsync(User.Identity.Name);
            var result = cartService.GetUser(appUser.Id);
            switch (result.ResultType)
            {
                case Core.BLL.Constant.EntityResultType.Success:
                    var u = result.Data.FirstOrDefault();
                    ProfileViewModel profile = new ProfileViewModel();
                    profile.UserName = u.AppUserName;
                    profile.Email = u.Email;
                    return View(profile);
                case Core.BLL.Constant.EntityResultType.Error:
                    break;
                case Core.BLL.Constant.EntityResultType.Notfound:
                    return View();
                case Core.BLL.Constant.EntityResultType.NonValidation:
                    break;
                case Core.BLL.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return NotFound();

            
        }
        
        public async Task<IActionResult> ProfileUpdate(string userName,string email)
        {

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            
            var result = cartService.UpdateUser(user.Id,userName,email);
            switch (result.ResultType)
            {
                case Core.BLL.Constant.EntityResultType.Success:
                   //return RedirectToAction("Profile");
                    return View("Profile",result.Data.FirstOrDefault());
                case Core.BLL.Constant.EntityResultType.Error:
                    break;
                case Core.BLL.Constant.EntityResultType.Notfound:
                    return View();
                case Core.BLL.Constant.EntityResultType.NonValidation:
                    break;
                case Core.BLL.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return NotFound();


        }
        public async Task<IActionResult> PasswordChange(string oldPassword,string newPassword)
        {
            var user = userManager.Users.FirstOrDefault(e => e.UserName == User.Identity.Name);

            var verifyResult = userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, oldPassword);

            if (verifyResult != PasswordVerificationResult.Failed) // either verigyResult equal to SuccessRehashNeeded or Success
            {
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user,newPassword);
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return NotFound();
            }
            return NotFound();
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
