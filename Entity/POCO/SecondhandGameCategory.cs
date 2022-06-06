using System;
using Core.ENTITY;

namespace Entity.POCO
{
    public class SecondhandGameCategory:IBASEENTITY
    {
        public int SecondhandGameID { get; set; }
        public int CategoryID { get; set; }
        public virtual SecondhandGame Game { get; set; }
        public virtual Category Category { get; set; }
    }
}
