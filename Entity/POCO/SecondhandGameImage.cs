using System;
using Core.ENTITY;

namespace Entity.POCO
{
    public class SecondhandGameImage:BaseEntity
    {
        public string ImageURL { get; set; }
        public int SecondhandGameID { get; set; }
        public virtual SecondhandGame SecondhandGame { get; set; }
    }
}
