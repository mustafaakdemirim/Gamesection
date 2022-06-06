using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLogic.Abstract;
using Entity.DTO;
using Entity.POCO;
using GamesectionAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GamesectionAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly IGameService gameService;

        public CartController(ICartService cartService,IGameService gameService)
        {
            this.cartService = cartService;
            this.gameService = gameService;
        }
        //public IActionResult Index()
        //{
        //    return Ok();
        //}

        //[HttpPost]
        //public IActionResult Deletes([FromBody]int gameId, string userName)
        //{
        //   var u = userManager.FindByNameAsync(userName);

        //    cartService.Delete(gameId, u.Id);
        //    var result = cartService.GetCart(u.Id);
            
        //    return Ok(result.Data);
        //}
        [HttpPost]
        public IActionResult ApiAddToCart([FromBody] CartDTO cartDTO)//string gameId)//, int quantity)
        {
            //int GameId = Convert.ToInt32(gameId);
            //var user =  userManager.FindByNameAsync(User.Identity.Name);
            var resultt = cartService.AddToCart(cartDTO); //Quantity = quantity,
            var result = cartService.GetCart(cartDTO.UserId);
            switch (result.ResultType)
            {
                case Core.BLL.Constant.EntityResultType.Success:
                    return Ok(result.Data.Count());
                case Core.BLL.Constant.EntityResultType.Error:
                    break;
                case Core.BLL.Constant.EntityResultType.Notfound:
                    break;
                case Core.BLL.Constant.EntityResultType.NonValidation:
                    break;
                case Core.BLL.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete([FromBody] DeleteGameModel model)
        {
            var resultt = cartService.Delete(model.gameId, model.userId);
            var result = gameService.GetCartByGameId(model.userId);
            switch (result.ResultType)
            {
                case Core.BLL.Constant.EntityResultType.Success:
                    return Ok(result.Data);
                case Core.BLL.Constant.EntityResultType.Error:
                    break;
                case Core.BLL.Constant.EntityResultType.Notfound:
                    break;
                case Core.BLL.Constant.EntityResultType.NonValidation:
                    break;
                case Core.BLL.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult RefreshBasketCount([FromBody] DeleteGameModel model)
        {

            var result = cartService.GetCart(model.userId);
            switch (result.ResultType)
            {
                case Core.BLL.Constant.EntityResultType.Success:
                    return Ok(result.Data.Count());
                case Core.BLL.Constant.EntityResultType.Error:
                    break;
                case Core.BLL.Constant.EntityResultType.Notfound:
                    break;
                case Core.BLL.Constant.EntityResultType.NonValidation:
                    break;
                case Core.BLL.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult ApiCartDetail([FromBody] DeleteGameModel model)
        {
            var gameDto = gameService.GetCartByGameId(model.userId);
            
            //var category = categoryService.GetAllActive();
            switch (gameDto.ResultType)
            {
                case Core.BLL.Constant.EntityResultType.Success:
                    //model.Category = category.Data.ToList();
                    //model.GameDTO = gameDto.Data;
                    //var result = JsonConvert.SerializeObject(gameDto.Data);
                    return Ok(gameDto.Data);
                case Core.BLL.Constant.EntityResultType.Error:
                    break;
                case Core.BLL.Constant.EntityResultType.Notfound:
                    return NotFound();
                case Core.BLL.Constant.EntityResultType.NonValidation:
                    break;
                case Core.BLL.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return NotFound();
        }
    }
}
