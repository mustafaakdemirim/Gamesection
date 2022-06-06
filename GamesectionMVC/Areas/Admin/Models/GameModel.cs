using System;
namespace GamesectionMVC.Areas.Admin.Models
{
    public class GameModel
    {
        public int stock { get; set; }
        public string gameName { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public object carts { get; set; }
        public string gameImageURL { get; set; }
        public string gameCategoryName { get; set; }
        public int id { get; set; }
        public bool active { get; set; }
        public bool deleted { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }

    }
}
