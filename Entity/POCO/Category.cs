using System;
using System.Collections.Generic;
using Core.ENTITY;

namespace Entity.POCO
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string CategoryImageURL { get; set; }
        public virtual ICollection<GameCategory> GameCategories { get; set; }
        public virtual ICollection<SecondhandGameCategory> SecondhandGameCategories { get; set; }
    }
}
