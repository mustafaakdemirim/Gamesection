using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GamesectionMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;



namespace GamesectionMVC.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            using HttpClient c = new HttpClient();
            //c.PostAsync()
            var apiUrl = "https://localhost:29723/api/Game/Index";
            Uri url = new Uri(apiUrl);
            using WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string json = client.DownloadString(url);
            List<GameModel> jsonList = JsonConvert.DeserializeObject<List<GameModel>>(json);
            return View(jsonList);
        }
    }
}
