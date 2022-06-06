using System;
using Core.ENTITY;

namespace Entity.POCO
{
    public class GameImage:BaseEntity
    {
        public string ImageURL { get; set; }
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
    }
}
