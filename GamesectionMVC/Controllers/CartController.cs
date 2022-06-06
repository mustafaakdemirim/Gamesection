using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Abstract;
using Entity.DTO;
using Entity.POCO;
using GamesectionMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GamesectionMVC.Controllers
{
    [Authorize(Roles ="UserApp")]
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly UserManager<AppUser> userManager;
        private readonly IGameService gameService;
        private readonly ICategoryService categoryService;

        public CartController(ICartService cartService, UserManager<AppUser> userManager, IGameService gameService, ICategoryService categoryService)
        {
            this.cartService = cartService;
            this.userManager = userManager;
            this.gameService = gameService;
            this.categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int gameId, int quantity)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cart = new CartDTO { Quantity = quantity, GameID = gameId, UserId = user.Id };
            var apiUrl = $"https://localhost:29723/api/Cart/ApiAddToCart";
            Uri url = new Uri(apiUrl);
            using HttpClient c = new HttpClient();
            var json = JsonConvert.SerializeObject(cart);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using var result = await c.PostAsync(url, content);
            var con = await result.Content.ReadAsStringAsync();

            //using HttpResponseMessage a = await c.PostAsync(url, content);
            //var responseContent = a.Content.ReadAsStringAsync().Result;

            //var user = await userManager.FindByNameAsync(User.Identity.Name);
            //var resultt = cartService.AddToCart(new CartDTO { Quantity = quantity, GameID = gameId, UserId = user.Id });
            //var result = cartService.GetCart(user.Id);
            //switch (result.ResultType)
            //{
            //    case Core.BLL.Constant.EntityResultType.Success:
            //        return Ok(result.Data.Count());
            //    case Core.BLL.Constant.EntityResultType.Error:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.Notfound:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.NonValidation:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.Warning:
            //        break;
            //    default:
            //        break;
            //}
            return Ok(con);
        }
        [HttpPost]
        public async Task<IActionResult> RefreshBasketCount()
        {
            DeleteGameModel model = new DeleteGameModel();
            var u = await userManager.FindByNameAsync(User.Identity.Name);
            model.userId = u.Id;

            var apiUrl = $"https://localhost:29723/api/Cart/RefreshBasketCount";
            Uri url = new Uri(apiUrl);
            using HttpClient c = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using var result = await c.PostAsync(url, content);
            var con = await result.Content.ReadAsStringAsync();
            //var result = cartService.GetCart(u.Id);
            //switch (result.ResultType)
            //{
            //    case Core.BLL.Constant.EntityResultType.Success:
            //        return Ok(result.Data.Count());
            //    case Core.BLL.Constant.EntityResultType.Error:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.Notfound:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.NonValidation:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.Warning:
            //        break;
            //    default:
            //        break;
            //}
            return Ok(con);
        }
        public async Task<IActionResult> CartDetail()
        {
            //CartDetailViewModel model = new CartDetailViewModel();
            DeleteGameModel model = new DeleteGameModel();
            var u = await userManager.FindByNameAsync(User.Identity.Name);
            model.userId = u.Id;

            var apiUrl = $"https://localhost:29723/api/Cart/ApiCartDetail";
            Uri url = new Uri(apiUrl);
            using HttpClient c = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using var result = await c.PostAsync(url, content);
            var con = await result.Content.ReadAsStringAsync();
            var newjson = JsonConvert.DeserializeObject<IEnumerable<GameDTO>>(con);
           
            

            return View(newjson);
            //var gameDto = gameService.GetCartByGameId(u.Id);
            ////var category = categoryService.GetAllActive();
            //switch (gameDto.ResultType)
            //{
            //    case Core.BLL.Constant.EntityResultType.Success:
            //        //model.Category = category.Data.ToList();
            //        //model.GameDTO = gameDto.Data;
            //        return View(gameDto.Data);
            //    case Core.BLL.Constant.EntityResultType.Error:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.Notfound:
            //        return View();
            //    case Core.BLL.Constant.EntityResultType.NonValidation:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.Warning:
            //        break;
            //    default:
            //        break;
            //}
            //return NotFound();
        }
        //public async Task<IActionResult> CountChange(int Id, int count)
        //{
        //    var u = await userManager.FindByNameAsync(User.Identity.Name);
        //    var result = cartService.Update(count, Id, u.Id);
        //    switch (result.ResultType)
        //    {
        //        case Core.BLL.Constant.EntityResultType.Success:
        //            return Ok();
        //        case Core.BLL.Constant.EntityResultType.Error:
        //            break;
        //        case Core.BLL.Constant.EntityResultType.Notfound:
        //            break;
        //        case Core.BLL.Constant.EntityResultType.NonValidation:
        //            break;
        //        case Core.BLL.Constant.EntityResultType.Warning:
        //            break;
        //        default:
        //            break;
        //    }
        //    return NotFound();
        //}
        [HttpPost]
        public async Task<IActionResult> Delete(int gameId, string userName)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            DeleteGameModel model = new DeleteGameModel();
            model.gameId = gameId;
            model.userId = user.Id;
            var apiUrl = $"https://localhost:29723/api/Cart/Delete";
            Uri url = new Uri(apiUrl);
            using HttpClient c = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using var result = await c.PostAsync(url, content);
            var con = await result.Content.ReadAsStringAsync();

            //var user = await userManager.FindByNameAsync(User.Identity.Name);
            //var d = cartService.Delete(gameId,user.Id);
            //var result = gameService.GetCartByGameId(user.Id);
            //switch (result.ResultType)
            //{
            //    case Core.BLL.Constant.EntityResultType.Success:
            //        return View("CartDetail", result.Data);
            //    case Core.BLL.Constant.EntityResultType.Error:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.Notfound:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.NonValidation:
            //        break;
            //    case Core.BLL.Constant.EntityResultType.Warning:
            //        break;
            //    default:
            //        break;
            //}
            return RedirectToAction("CartDetail");
        }
    }
}
