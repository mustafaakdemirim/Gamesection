using System;
using System.Collections.Generic;
using Entity.DTO;
using Entity.POCO;

namespace GamesectionMVC.Models
{
    public class HeaderViewModel
    {
        public List<Category> Category { get; set; }
        public List<CategoryDTO> CategoryDTO { get; set; }
        public string UserName { get; set; }
    }
}
