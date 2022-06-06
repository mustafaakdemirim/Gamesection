using System;
using Core.ENTITY;

namespace Entity.POCO
{
    public class Cart:BaseEntity
    {
        public int GameID { get; set; }
        public int AppUserId { get; set; }
        public int Quantity { get; set; }
        public virtual Game Game { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
