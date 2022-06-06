using System;
using System.Collections.Generic;
using System.Linq;
using BussinessLogic.Abstract;
using Core.BLL.Constant;
using Core.BLL.Logger;
using DataAccess.Abstract;
using Entity.DTO;
using Entity.POCO;

namespace BussinessLogic.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDAL cartDAL;

        public CartManager(ICartDAL cartDAL)
        {
            this.cartDAL = cartDAL;
        }
        public EntityResult<IEnumerable<CartDTO>> AddToCart(CartDTO cartDTO)
        {
            try
            {
                var cart = cartDAL.AddToCart(cartDTO).ToList();
                if (cart != null && cart.Count() > 0)
                {
                    return new EntityResult<IEnumerable<CartDTO>>(cart, "Success");
                }
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<IEnumerable<CartDTO>> AddToCart(CartDTO cartDTO) Tarih: " + DateTime.Now + " Oyun ID: " + cartDTO.GameID + " User ID: " + cartDTO.UserId + "  Oyun Adı: " + cartDTO.GameName + " Sepete Eklenemedi, NotFound ", LogType.Notfound);
                return new EntityResult<IEnumerable<CartDTO>>(null, "NotFound", EntityResultType.Notfound);
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<IEnumerable<CartDTO>> AddToCart(CartDTO cartDTO) Tarih: " + DateTime.Now + " Oyun ID: " + cartDTO.GameID + " User ID: " + cartDTO.UserId + "  Oyun Adı: " + cartDTO.GameName + " Sepete Eklenemedi, Error: "+ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<CartDTO>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<bool> Delete(int gameid, int userId)
        {
            try
            {
                var cart = cartDAL.Delete(gameid,userId);
                if (cart)
                {
                    return new EntityResult<bool>(cart, "Success");
                }
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<bool> Delete(int gameid, int userId) Tarih: " + DateTime.Now + " Oyun ID: " + gameid + " User ID: " + userId + " Sepetten Çıkartılamadı, NotFound ", LogType.Notfound);
                return new EntityResult<bool>(false, "NotFound", EntityResultType.Notfound);
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<bool> Delete(int gameid, int userId) Tarih: " + DateTime.Now + " Oyun ID: " + gameid + " User ID: " + userId + " Sepetten Çıkartılamadı, Error: "+ex.ToInnest().Message, LogType.Error);
                return new EntityResult<bool>(false, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<CartDTO>> GetCart(int UserId)
        {
            try
            {
                
                var result = cartDAL.GetCart(UserId);
                if (result != null && result.Count() > 0)
                {
                    return new EntityResult<IEnumerable<CartDTO>>(result, "Success");
                }
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<IEnumerable<CartDTO>> GetCart(int UserId) Tarih: " + DateTime.Now +  " User ID: " + UserId + " Sepet Çekilemedi, NotFound ", LogType.Notfound);
                return new EntityResult<IEnumerable<CartDTO>>(null, "NotFound", EntityResultType.Notfound);
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<IEnumerable<CartDTO>> GetCart(int UserId) Tarih: " + DateTime.Now + " User ID: " + UserId + " Sepet Çekilemedi, Error: "+ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<CartDTO>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<Cart> GetEntity(int userId, int gameId)
        {
            try
            {
                var cart = cartDAL.GetEntity(userId, gameId);
                if (cart != null)
                {
                    return new EntityResult<Cart>(cart, "Success");
                }
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<Cart> GetEntity(int userId, int gameId) Tarih: " + DateTime.Now + " Oyun ID: " + gameId + " User ID: " + userId + " Sepet Çekilemedi, NotFound ", LogType.Notfound);
                return new EntityResult<Cart>(null, "NotFound",EntityResultType.Notfound);
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<Cart> GetEntity(int userId, int gameId) Tarih: " + DateTime.Now + " Oyun ID: " + gameId + " User ID: " + userId + " Sepet Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<Cart>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<UserDTO>> GetUser(int userId)
        {
            try
            {

                var result = cartDAL.GetUser(userId);
                if (result != null && result.Count() > 0)
                {
                    return new EntityResult<IEnumerable<UserDTO>>(result, "Success");
                }
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<IEnumerable<UserDTO>> GetUser(int userId) Tarih: " + DateTime.Now + " User ID: " + userId + " Kullanıcı Çekilemedi, NotFound ", LogType.Notfound);
                return new EntityResult<IEnumerable<UserDTO>>(null, "NotFound", EntityResultType.Notfound);
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<IEnumerable<UserDTO>> GetUser(int userId) Tarih: " + DateTime.Now + " User ID: " + userId + " Kullanıcı Çekilemedi, Error: " + ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<UserDTO>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }

        public EntityResult<int> Update(int quantity, int gameId, int userId)
        {
            try
            {
                var cart = cartDAL.GetEntity(userId, gameId);
                if (cart != null)
                {
                    cart.Quantity = quantity;
                    cartDAL.Update(cart);
                    return new EntityResult<int>(cart.Quantity, "Success");
                }
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<int> Update(int quantity, int gameId, int userId) Tarih: " + DateTime.Now + " Oyun ID: " + gameId + " User ID: " + userId + " Sepet Güncellenemedi, NotFound ", LogType.Notfound);
                return new EntityResult<int>(0, "Notfound",EntityResultType.Notfound);

            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<int> Update(int quantity, int gameId, int userId) Tarih: " + DateTime.Now + " Oyun ID: " + gameId + " User ID: " + userId + " Sepet Güncellenemedi, Error: "+ex.ToInnest().Message, LogType.Error);
                return new EntityResult<int>(0, "Error: "+ex.ToInnest().Message, EntityResultType.Error);

            }
        }

        public EntityResult<IEnumerable<UserDTO>> UpdateUser(int userId, string userName, string email)
        {
            try
            {

                var result = cartDAL.UpdateUser(userId,userName,email);
                if (result != null && result.Count() > 0)
                {
                    GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<IEnumerable<UserDTO>> UpdateUser(int userId, string userName, string email) Tarih: " + DateTime.Now + " User ID: " + userId + " UserName: " + userName + " Email: " + email + " Kullanıcı Güncellendi, Success ",LogType.Update);
                    return new EntityResult<IEnumerable<UserDTO>>(result, "Success");
                }
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<IEnumerable<UserDTO>> UpdateUser(int userId, string userName, string email) Tarih: " + DateTime.Now + " User ID: " + userId + " UserName: " + userName + " Email: " + email + " Kullanıcı Güncellenemedi, NotFound ", LogType.Notfound);
                return new EntityResult<IEnumerable<UserDTO>>(null, "NotFound", EntityResultType.Notfound);
            }
            catch (Exception ex)
            {
                GamesectionLog.LogAdd("Logun Geldiği Yer: CartManager>EntityResult<IEnumerable<UserDTO>> UpdateUser(int userId, string userName, string email) Tarih: " + DateTime.Now + " User ID: " + userId + " UserName: " + userName + " Email: " + email + " Kullanıcı Güncellenemedi, Error: "+ex.ToInnest().Message, LogType.Error);
                return new EntityResult<IEnumerable<UserDTO>>(null, ex.ToInnest().Message, EntityResultType.Error);
            }
        }
    }
}
