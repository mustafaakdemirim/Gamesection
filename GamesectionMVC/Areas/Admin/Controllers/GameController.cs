using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BussinessLogic.Abstract;
using Entity.POCO;
using GamesectionMVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamesectionMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class GameController : Controller
    {
        private readonly IGameService gameService;
        private readonly IGameCategoryService gameCategoryService;
        private readonly IWebHostEnvironment hostEnvironment;

        public GameController(IGameService gameService,IGameCategoryService gameCategoryService, IWebHostEnvironment hostEnvironment)
        {
            this.gameService = gameService;
            this.gameCategoryService = gameCategoryService;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult GameList()
        {
            var apiUrl = "https://localhost:29723/api/Game/Index";
            Uri url = new Uri(apiUrl);
            using WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string json = client.DownloadString(url);
            List<GameModel> jsonList = JsonConvert.DeserializeObject<List<GameModel>>(json);
            return View(jsonList);

        }
        [HttpPost]
        public IActionResult DeleteGame(int gameId)
        {
            var result = gameService.Delete(gameId);
            switch (result.ResultType)
            {
                case Core.BLL.Constant.EntityResultType.Success:
                    return RedirectToAction("GameList");
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
            return Ok();
            var apiUrl = "https://localhost:29723/api/Game/Index";
            Uri url = new Uri(apiUrl);
            using WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string json = client.DownloadString(url);
            List<GameModel> jsonList = JsonConvert.DeserializeObject<List<GameModel>>(json);
            return View("GameList",jsonList);

        }
        [HttpPost]
        public PartialViewResult UpdateGame(int game_id)
        {
            var result = gameService.GetGameAndImageByGameId(game_id);
            return PartialView("EditModal",result.Data);
            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGameNew()//IFormFile formFiles)//string gameName, int gameId, string description, decimal price, int categoryID)
        {
            var files = Request.Form.Files;
            foreach (IFormFile item in files)
            {
                string FileName = item.Name;
            }
            //var resim = formFiles;
            string wwwRootPath = hostEnvironment.WebRootPath;
            //string fileName = Path.GetFileNameWithoutExtension(resim.FileName);
            //string extension = Path.GetExtension(resim.FileName);
            //var yeniAd = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //string path = Path.Combine(wwwRootPath + "/img/cards", fileName);
            //using (var fileStream = new FileStream(path, FileMode.Create))
            //{
                //await resim.CopyToAsync(fileStream);
            //}
            //Game game = new Game() { Name = gameName, Description = description, Price = price };
            //GameCategory category = new GameCategory() { GameID = gameId, CategoryID = categoryID };
            //var categoryUpdate = gameCategoryService.Update(category, categoryID, gameId);
            
            //var gameUpdate = gameService.Update(game, gameId);
            return RedirectToAction("GameList");
            
        }
    }
}
