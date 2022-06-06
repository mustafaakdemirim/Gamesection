using System;
using System.Collections.Generic;
using Core.ENTITY;

namespace Entity.POCO
{
    public class Game : BaseEntity
    {
        public int Stock { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<GameImage> GameImages { get; set; }
        public virtual ICollection<GameCategory> GameCategories { get; set; }   
    }
}
