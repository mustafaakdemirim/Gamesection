using System;
using System.Collections.Generic;
using Core.ENTITY;

namespace Entity.POCO
{
    public class GameCategory:IBASEENTITY
    {
        public int GameID { get; set; }
        public int CategoryID { get; set; }
        public virtual Game Game { get; set; }
        public virtual Category Category { get; set; }
    }
}
