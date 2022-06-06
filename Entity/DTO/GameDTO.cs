using System;
using System.Collections.Generic;
using Entity.POCO;

namespace Entity.DTO
{
    public class GameDTO
    {
        public int ID { get; set; }
        public string GameName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string GameImageURL { get; set; }
        public string GameCategoryName { get; set; }
        public int CategoryID { get; set; }
        public int CartCount { get; set; }
        public List<Category> Categories { get; set; }
    }
}
