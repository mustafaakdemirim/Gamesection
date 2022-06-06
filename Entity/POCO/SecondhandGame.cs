using System;
using System.Collections.Generic;
using Core.ENTITY;

namespace Entity.POCO
{
    public class SecondhandGame:BaseEntity
    {
        public string GameName { get; set; }
        public int AddUserID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<SecondhandGameImage> SecondhandGameImages { get; set; }
        public virtual ICollection<SecondhandGameCategory> GameCategories { get; set; }
    }
}
