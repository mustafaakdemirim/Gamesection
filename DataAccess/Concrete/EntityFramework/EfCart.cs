using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.DTO;
using Entity.POCO;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCart : EfRepo<Cart,GamesectionDbContext>,ICartDAL
    {
        private readonly GamesectionDbContext db;

        public EfCart(GamesectionDbContext db) : base(db)
        {
            this.db = db;
        }

        public IEnumerable<CartDTO> AddToCart(CartDTO cartDTO)
        {
            var cart = db.Cart.FirstOrDefault(x => x.AppUserId == cartDTO.UserId && x.GameID == cartDTO.GameID);
            if (cart == null)
            {
                db.Cart.Add(new Cart
                {
                    AppUserId = cartDTO.UserId,
                    GameID = cartDTO.GameID,
                    Quantity = cartDTO.Quantity
                });
                db.SaveChanges();
            }
            var carts =
            from cartt in db.Cart
            join game in db.Game
            on cartt.GameID equals game.ID
            join gameImage in db.GameImage
            on game.ID equals gameImage.GameID
            join appUser in db.Users
            on cartt.AppUserId equals appUser.Id
            where cartt.AppUserId == cartDTO.UserId
            select new CartDTO
            {
                Quantity = cart.Quantity,
                UserId = appUser.Id,
                GameID = game.ID,
                GameName = game.Name,
                GameImageURL = gameImage.ImageURL,
                Price = game.Price
            };
            return carts;
        }

        public IEnumerable<CartDTO> GetCart(int userId)
        {
            var carts =
            from cart in db.Cart
            join game in db.Game
            on cart.GameID equals game.ID
            join gameImage in db.GameImage
            on game.ID equals gameImage.GameID
            join appUser in db.Users
            on cart.AppUserId equals appUser.Id
            where cart.AppUserId == userId
            select new CartDTO
            {
                Quantity = cart.Quantity,
                UserId = appUser.Id,
                GameID = game.ID,
                GameName = game.Name,
                GameImageURL = gameImage.ImageURL,
                
            };
            return carts;
        }

        public bool Delete(int gameid,int userId)
        {
            var result = db.Cart.Where(x => x.AppUserId == userId && x.GameID == gameid).FirstOrDefault();
            db.Remove(result);
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public IEnumerable<UserDTO> GetUser(int userId)
        {
            var user =
            from appUser in db.Users
            where appUser.Id == userId
            select new UserDTO
            {
                AppUserName = appUser.UserName,
                Email = appUser.Email
            };
            return user;
        }

        public IEnumerable<UserDTO> UpdateUser(int userId, string userName,string email)
        {
            var result = db.Users.Where(x => x.Id == userId).FirstOrDefault();
            result.UserName = userName;
            result.NormalizedUserName = userName.ToUpper();
            result.Email = email;
            result.NormalizedEmail = email.ToUpper();
            db.Update(result);
            db.SaveChanges();
            
                var user =
                from appUser in db.Users
                where appUser.Id == userId
                select new UserDTO
                {
                    AppUserName = appUser.UserName,
                    Email = appUser.Email
                };
            return user;
        }

        public Cart GetEntity(int userId, int gameId)
        {
            var result = db.Cart.Where(x => x.AppUserId == userId && x.GameID == gameId).FirstOrDefault();
            return result;
        }
    }
}
