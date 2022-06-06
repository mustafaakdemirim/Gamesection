using System;
namespace Entity.DTO
{
    public class SecondhandGameDTO
    {
        public int ID { get; set; }
        public int AddUserID { get; set; }
        public string GameName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string GameImageURL { get; set; }
        public string GameCategoryName { get; set; }
        public int CategoryID { get; set; }
        public string AddUserName { get; set; }
    }
}
