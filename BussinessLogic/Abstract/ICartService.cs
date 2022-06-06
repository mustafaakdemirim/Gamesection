using System;
using System.Collections.Generic;
using Core.BLL.Constant;
using Entity.DTO;
using Entity.POCO;

namespace BussinessLogic.Abstract
{
    public interface ICartService
    {
        EntityResult<IEnumerable<CartDTO>> AddToCart(CartDTO cartDTO);
        EntityResult<IEnumerable<CartDTO>> GetCart(int UserId);
        EntityResult<int> Update(int count, int productId, int userId);
        EntityResult<bool> Delete(int gameid, int userId);
        EntityResult<IEnumerable<UserDTO>> GetUser(int userId);
        EntityResult<IEnumerable<UserDTO>> UpdateUser(int userId, string userName, string email);
        EntityResult<Cart> GetEntity(int userId, int gameId);
    }
}
