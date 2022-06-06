using System;
namespace Entity.DTO
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageURL { get; set; }
        public int CartCount { get; set; }
    }
}
