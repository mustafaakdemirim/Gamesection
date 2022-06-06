using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BussinessLogic.Abstract;
using GamesectionMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GamesectionMVC.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            var apiUrl = $"https://localhost:29723/api/Game/Details/{id}";
            Uri url = new Uri(apiUrl);
            using WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString(url);
            GameModel jsonList = JsonConvert.DeserializeObject<GameModel>(json);
            return View(jsonList);
        }
    }
}
