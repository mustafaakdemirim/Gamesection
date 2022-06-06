using System;
using System.Collections.Generic;
using Core.DAL;
using Entity.DTO;
using Entity.POCO;

namespace DataAccess.Abstract
{
    public interface ICartDAL : IRepo<Cart>
    {
        IEnumerable<CartDTO> AddToCart(CartDTO cartDTO);
        IEnumerable<CartDTO> GetCart(int userId);
        bool Delete(int gameid, int userId);
        IEnumerable<UserDTO> GetUser(int userId);
        IEnumerable<UserDTO> UpdateUser(int userId, string userName, string email);
        Cart GetEntity(int userId, int gameId);
    }
}
