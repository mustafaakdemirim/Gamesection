using System;
using System.Collections.Generic;
using Entity.DTO;
using Entity.POCO;

namespace GamesectionMVC.Models
{
    public class CartDetailViewModel
    {
        public List<Category> Category { get; set; }
        public IEnumerable<GameDTO> GameDTO { get; set; }
        public int CartCount { get; set; }
    }
}
