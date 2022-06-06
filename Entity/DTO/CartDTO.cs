using System;
namespace Entity.DTO
{
    public class CartDTO
    {
        public bool Active { get; set; }
        public bool Delete { get; set; }
        public int UserId { get; set; }
        public int GameID { get; set; }
        public int Quantity { get; set; }
        public string GameName { get; set; }
        public string GameImageURL { get; set; }
        public decimal Price { get; set; }
        
    }
}
